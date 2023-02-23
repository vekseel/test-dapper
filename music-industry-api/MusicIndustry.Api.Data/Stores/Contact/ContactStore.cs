using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicIndustry.Api.Common.Helpers;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;
using MusicIndustry.Api.Data.Stores.Contact;

namespace MusicIndustry.Api.Data.Stores;

public class ContactStore : BaseStore, IContactStore
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ContactStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
        : base(connectionStrings, context, mapper)
    {
        _context = context ?? ThrowHelper.NullArgument<ApplicationDbContext>();
        _mapper = mapper ?? ThrowHelper.NullArgument<IMapper>();
    }

    public override async Task<K> CreateEntry<T, K>(CreateCommandRequest<T> request)
    {
        var mappedEntry = MapCreateModel<T, K>(request);

        var createModel = request.Entry as ContactCreateModel;

        try
        {
            await _context.AddAsync(mappedEntry);

            await _context.SaveChangesAsync();

            if (createModel.MusicLabelIds != null)
            {
                foreach (var musicLabel in createModel.MusicLabelIds)
                {
                    var item = MapMusicLabelContacts(musicLabel);

                    item.ContactId = Convert.ToInt32(mappedEntry.Id);

                    _context.Add(item);
                }
            }

            if (createModel.PlatformIds != null)
            {
                foreach (var platform in createModel.PlatformIds)
                {
                    var item = MapPlatformContacts(platform);

                    item.ContactId = Convert.ToInt32(mappedEntry.Id);

                    _context.Add(item);
                }
            }

            if (createModel.MusicianIds != null)
            {
                foreach (var platform in createModel.MusicianIds)
                {
                    var item = MapMusicianContacts(platform);

                    item.ContactId = Convert.ToInt32(mappedEntry.Id);

                    _context.Add(item);
                }
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException(ex.Message);
        }

        return mappedEntry.Id;
    }

    public override async Task<bool> UpdateEntry<T, K>(UpdateCommandRequest<T> request)
    {
        var mappedEntry = MapUpdateModel<T, K>(request);
        var existingEntry = await _context.FindAsync(DataModelType, mappedEntry.Id).ConfigureAwait(false);
        if (existingEntry == null)
        {
            return false;
        }

        var updateModel = request.Entry as ContactUpdateModel;

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            #region Check platform relations

            var currentPlatforms =
                await _context.PlatformContacts?.Where((m) => m.ContactId == updateModel.Id).ToListAsync();
            var platformsForDelete = updateModel.PlatformIds != null
                ? currentPlatforms.Where(p => !updateModel.PlatformIds.Any(p2 => p2.PlatformId == p.PlatformId))
                : currentPlatforms;
            var platformsForAdd =
                updateModel.PlatformIds?.Where(p => !currentPlatforms.Any(p2 => p2.PlatformId == p.PlatformId));

            if (platformsForDelete != null && platformsForDelete.Any())
            {
                _context.PlatformContacts.RemoveRange(platformsForDelete);
            }

            if (platformsForAdd != null && platformsForAdd.Any())
            {
                foreach (var item in platformsForAdd)
                {
                    item.ContactId = updateModel.Id;
                }

                await _context.PlatformContacts.AddRangeAsync(_mapper.Map<List<PlatformContacts>>(platformsForAdd));
            }

            #endregion

            #region Check musician relations

            var currentMusicians =
                await _context.MusicianContacts.Where((m) => m.ContactId == updateModel.Id).ToListAsync();
            var musiciansForDelete = updateModel.MusicianIds != null
                ? currentMusicians.Where(p => !updateModel.MusicianIds.Any(p2 => p2.MusicianId == p.MusicianId))
                : currentMusicians;
            var musiciansForAdd =
                updateModel.MusicianIds?.Where(p => !currentMusicians.Any(p2 => p2.MusicianId == p.MusicianId));

            if (musiciansForDelete != null && musiciansForDelete.Any())
            {
                _context.MusicianContacts.RemoveRange(musiciansForDelete);
            }

            if (musiciansForAdd != null && musiciansForAdd.Any())
            {
                foreach (var item in musiciansForAdd)
                {
                    item.ContactId = updateModel.Id;
                } 

                await _context.MusicianContacts.AddRangeAsync(_mapper.Map<List<MusicianContacts>>(musiciansForAdd));
            }

            #endregion

            #region Check labels relations

            var currentLabels =
                await _context.MusicLabelContacts.Where((m) => m.ContactId == updateModel.Id).ToListAsync();
            var musicLabelsForDelete = updateModel.MusicLabelIds != null ?
                currentLabels.Where(p => !updateModel.MusicLabelIds.All(p2 => p2.MusicLabelId == p.MusicLabelId)).ToList()
                : currentLabels;
            var musicLabelsForAdd =
                updateModel.MusicLabelIds?.Where(p => !currentLabels.Any(p2 => p2.MusicLabelId == p.MusicLabelId));

            if (musicLabelsForDelete != null && musicLabelsForDelete.Any())
            {
                _context.MusicLabelContacts.RemoveRange(musicLabelsForDelete);
            }

            if (musicLabelsForAdd != null && musicLabelsForAdd.Any())
            {
                foreach (var item in musicLabelsForAdd)
                {
                    item.ContactId = updateModel.Id;
                }

                await _context.MusicLabelContacts.AddRangeAsync(
                    _mapper.Map<List<MusicLabelContacts>>(musicLabelsForAdd));
            }

            #endregion

            mappedEntry.DateCreated = ((IBaseEntryModel<K>)existingEntry).DateCreated;
            _context.Entry(existingEntry).CurrentValues.SetValues(mappedEntry);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            await transaction.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            throw new HttpRequestException(ex.Message);
            
            return false;
        }
    }

    private MusicLabelContacts MapMusicLabelContacts(MusicLabelContactsCreateModel model)
    {
        return _mapper.Map<MusicLabelContacts>(model);
    }

    private PlatformContacts MapPlatformContacts(PlatformContactsCreateModel model)
    {
        return _mapper.Map<PlatformContacts>(model);
    }

    private MusicianContacts MapMusicianContacts(MusicianContactsCreateModel model)
    {
        return _mapper.Map<MusicianContacts>(model);
    }

    protected override Type DataModelType => typeof(Models.Contact);
    protected override string EntriesProcedureName => ContactGetEntriesProcedure.Name;
    protected override string EntryProcedureName => ContactGetEntriesProcedure.Name;
}