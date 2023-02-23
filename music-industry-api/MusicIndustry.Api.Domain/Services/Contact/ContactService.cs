using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicIndustry.Api.Common.Helpers;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Core.Models.Query.Contact;
using MusicIndustry.Api.Data.Stores;
using MusicIndustry.Api.Data.Stores.Contact;
using MusicIndustry.Api.Data.Stores.MusicianContact;

namespace MusicIndustry.Api.Domain.Services.Contact;

public class ContactService : BaseService, IContactService
{
    private readonly IContactStore _store;
    private readonly IMusicLabelContactsStore _musicLabelContactsStore;
    private readonly IMusicianContactsStore _musicianContactsStore;
    private readonly IPlatformContactsStore _platformContactsStore;
    private readonly IMusicLabelStore _musicLabelStore;
    private readonly IMusicianStore _musicianStore;
    private readonly IPlatformStore _platformStore;
    private readonly ILogger<ContactService> _logger;

    public ContactService(IContactStore contactStore, ILogger<ContactService> logger, IMapper mapper, 
        IMusicLabelContactsStore musicLabelContactsStore,
        IMusicianContactsStore musicianContactsStore,
        IPlatformContactsStore platformContactsStore,
        IMusicLabelStore musicLabelStore,
        IMusicianStore musicianStore,
        IPlatformStore platformStore)
        : base(contactStore, logger, mapper)
    {
        _store = contactStore ?? ThrowHelper.NullArgument<IContactStore>();
        _logger = logger ?? ThrowHelper.NullArgument<ILogger<ContactService>>();
        _musicLabelContactsStore = musicLabelContactsStore ?? ThrowHelper.NullArgument<IMusicLabelContactsStore>();
        _musicLabelContactsStore = musicLabelContactsStore ?? ThrowHelper.NullArgument<IMusicLabelContactsStore>();
        _musicianContactsStore = musicianContactsStore ?? ThrowHelper.NullArgument<IMusicianContactsStore>();
        _platformContactsStore = platformContactsStore ?? ThrowHelper.NullArgument<IPlatformContactsStore>();
        _musicLabelStore = musicLabelStore ?? ThrowHelper.NullArgument<IMusicLabelStore>();
        _musicianStore = musicianStore ?? ThrowHelper.NullArgument<IMusicianStore>();
        _platformStore = platformStore ?? ThrowHelper.NullArgument<IPlatformStore>();
    }

    public override async Task<UpdateCommandResponse> UpdateEntry<T, K>(UpdateCommandRequest<T> request)
    {
        #region Input validation
        if (request == null)
        {
            return new UpdateCommandResponse
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "Request is null."
            };
        }

        if (!(request.Entry as ContactCreateModel).ContactRequiredRelationsExist())
        {
            return new UpdateCommandResponse
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "There must be at least one relation to Platform, Musician, or MusicianLabel"
            };
        }

        if (!(request.Entry as ContactCreateModel).ContactRequiredFieldsExist())
        {
            return new UpdateCommandResponse
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "At least one of the fields must be specified: Email, Fax, PhoneBusiness, PhoneCell"
            };
        }

        #endregion

        try
        {
            var success = await _store.UpdateEntry<T, K>(request).ConfigureAwait(false);
            if (!success)
            {
                return new UpdateCommandResponse
                {
                    Success = false,
                    Code = ResponseCode.NotFound
                };
            }
            return new UpdateCommandResponse
            {
                Success = true,
                Code = ResponseCode.Success
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UpdateCommandResponse
            {
                Success = false,
                Code = ResponseCode.Error,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<CreateCommandResponse<K>> CreateEntry<T, K>(CreateCommandRequest<T> request)
    {
        #region Input validation
        if (request == null)
        {
            return new CreateCommandResponse<K>
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "Request is null."
            };
        }

        if (!(request.Entry as ContactCreateModel).ContactRequiredRelationsExist())
        {
            return new CreateCommandResponse<K>
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "There must be at least one relation to Platform, Musician, or MusicianLabel"
            };
        }

        if (!(request.Entry as ContactCreateModel).ContactRequiredFieldsExist())
        {
            return new CreateCommandResponse<K>
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "At least one of the fields must be specified: Email, Fax, PhoneBusiness, PhoneCell"
            };
        }

        #endregion

        try
        {
            var id = await _store.CreateEntry<T, K>(request).ConfigureAwait(false);
            return new CreateCommandResponse<K>
            {
                Id = id,
                Success = true,
                Code = ResponseCode.Success
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CreateCommandResponse<K>
            {
                Success = false,
                Code = ResponseCode.Error,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<EntriesQueryResponse<T>> GetEntries<T>(EntriesQueryRequest request)
    {
        if (request == null)
        {
            return new EntriesQueryResponse<T>
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "Request is null."
            };
        }

        try
        {
            var contacts = await _store.GetEntries<T>(request);

            foreach (var contact in contacts.Data)
            {
                await AddCountOfRelations(contact as ContactsReportModel);
            }

            return contacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new EntriesQueryResponse<T>
            {
                Success = false,
                Code = ResponseCode.Error,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<EntryQueryResponse<T>> GetEntry<T, K>(EntryQueryRequest<K> request)
    {
        if (request == null)
        {
            return new EntryQueryResponse<T>
            {
                Success = false,
                Code = ResponseCode.BadRequest,
                ErrorMessage = "Request is null."
            };
        }

        try
        {
            var contact =  await _store.GetEntry<T, K>(request).ConfigureAwait(false);

            await AddRelations(contact.Data as ContactReportModel);

            return contact;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new EntryQueryResponse<T>
            {
                Success = false,
                Code = ResponseCode.Error,
                ErrorMessage = ex.Message
            };
        }
    }

    private async Task AddCountOfRelations(ContactsReportModel contact)
    {
        var request = new EntriesQueryRequest { Limit = Int32.MaxValue, Offset = 0 };

        // ToDo: Bad decision, request all items by id
        var allPlatformRelations = (await _platformContactsStore.GetEntries<PlatformContactsReportModel>(request).ConfigureAwait(false)).Data;
        var allMusicianRelations = (await _musicianContactsStore.GetEntries<MusicianContactsReportModel>(request).ConfigureAwait(false)).Data;
        var allMusicLabelRelations = (await _musicLabelContactsStore.GetEntries<MusicLabelContactsReportModel>(request).ConfigureAwait(false)).Data;

        contact.Platforms = (await _platformStore.GetEntries<PlatformReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allPlatformRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.PlatformId == d.Id)).Count();
        contact.Musicians = (await _musicianStore.GetEntries<MusicianReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allMusicianRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.MusicianId == d.Id)).Count();
        contact.MusicLabels = (await _musicLabelStore.GetEntries<MusicLabelReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allMusicLabelRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.MusicLabelId == d.Id)).Count();
    }

    private async Task AddRelations(ContactReportModel contact)
    {
        var request = new EntriesQueryRequest {Limit = Int32.MaxValue, Offset = 0};

        // ToDo: Bad decision, request all items by id
        var allPlatformRelations = (await _platformContactsStore.GetEntries<PlatformContactsReportModel>(request).ConfigureAwait(false)).Data;
        var allMusicianRelations = (await _musicianContactsStore.GetEntries<MusicianContactsReportModel>(request).ConfigureAwait(false)).Data;
        var allMusicLabelRelations = (await _musicLabelContactsStore.GetEntries<MusicLabelContactsReportModel>(request).ConfigureAwait(false)).Data;

        contact.Platforms = (await _platformStore.GetEntries<PlatformReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allPlatformRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.PlatformId == d.Id));
        contact.Musicians = (await _musicianStore.GetEntries<MusicianReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allMusicianRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.MusicianId == d.Id));
        contact.MusicLabels = (await _musicLabelStore.GetEntries<MusicLabelReportModel>(request).ConfigureAwait(false))
            .Data.Where((d) => allMusicLabelRelations.Where((m) => m.ContactId == contact.Id)
                .Any(m => m.MusicLabelId == d.Id));
    }
}