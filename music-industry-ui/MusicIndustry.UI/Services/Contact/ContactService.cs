using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MusicIndustry.Api.Core.Clients;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.UI.Helpers;
using MusicIndustry.UI.Models;
using MusicIndustry.UI.Models.Contact;

namespace MusicIndustry.UI.Services.Contact;

public class ContactService : IContactService
{
	private readonly IContactClient _contactClient;
	private readonly IMusicianClient _musicianClient;
	private readonly IMusicLabelClient _musicLabelClient;
	private readonly IPlatformClient _platformClient;
	private readonly ILogger<ContactService> _logger;

	public ContactService(IContactClient client,IMusicianClient musicianClient,IMusicLabelClient musicLabelClient,IPlatformClient platformClient,ILogger<ContactService> logger)
	{
		_contactClient = client ?? ThrowHelper.NullArgument<IContactClient>();
		
		_musicianClient = musicianClient ?? ThrowHelper.NullArgument<IMusicianClient>();
		_musicLabelClient = musicLabelClient ?? ThrowHelper.NullArgument<IMusicLabelClient>();
		_platformClient = platformClient ?? ThrowHelper.NullArgument<IPlatformClient>();
		
		_logger = logger ?? ThrowHelper.NullArgument<ILogger<ContactService>>();
	}

	public async Task<ServiceResult<ContactGetEntriesViewModel>> GetEntries(int offset, int limit)
	{
		try
		{
			var response = await _contactClient.GetEntries(new EntriesQueryRequest { Offset = offset, Limit = limit });
			return ServiceResult.CreateInstance(
				response,
				new ContactGetEntriesViewModel
				{
					Entries = response.Data
				},
				new Paging(response.TotalCount, offset, limit, (o, l) => UIRoutesHelper.Contact.GetEntries.GetUrl(o, l))
			);
		}
		catch(Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return ServiceResult.CreateErrorInstance<ContactGetEntriesViewModel>(ex.Message, ResponseCode.Error);
		}
	}

	public async Task<ServiceResult<ContactCreateEntryViewModel>> GetCreateEntryViewModel()
	{
        return ServiceResult.CreateInstance(new BaseResponse { Success = true, Code = ResponseCode.Success },
	        new ContactCreateEntryViewModel{ Items = await GetAllRelations() });
    }

	public async Task<ServiceResult> CreateEntry(ContactCreateEntryViewModel model)
	{
		try
		{
			var request = new ContactCreateModel
			{
				FirstName = model.Form.FirstName,
				LastName = model.Form.LastName,
				Title = model.Form.Title,
				Company = model.Form.Company,
				Email = model.Form.Email,
				PhoneCell = model.Form.PhoneCell,
				PhoneBusiness = model.Form.PhoneBusiness,
				Fax = model.Form.Fax,
				AddressLine1 = model.Form.AddressLine1,
				AddressLine2 = model.Form.AddressLine2,
				City = model.Form.City,
				State = model.Form.State,
				Zip = model.Form.Zip,
				IsActive = model.Form.IsActive,
				MusicianIds = CreateMusicianContactsList(model),
				PlatformIds = CreatePlatformContactsList(model),
				MusicLabelIds = CreateLabelsContactsList(model)
			};
			
			var response = await _contactClient.CreateEntry(new CreateCommandRequest<ContactCreateModel> { Entry = request });
			return ServiceResult.CreateInstance(response);
		}
		catch(Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return ServiceResult.CreateErrorInstance(ex.Message, ResponseCode.Error);
		}
	}

	public async Task<ServiceResult<ContactUpdateEntryViewModel>> GetUpdateEntryViewModel(int id)
	{
		try
		{
			var response = await _contactClient.GetEntry(id);
			
			if(!response.Success)
			{
				return ServiceResult.CreateErrorInstance<ContactUpdateEntryViewModel>(response.ErrorMessage,
					response.Code);
			}

			return ServiceResult.CreateInstance(
				response,
				new ContactUpdateEntryViewModel
				{
					Form = new ContactUpdateEntryViewModel.FormModel
					{
						Id = response.Data.Id,
						FirstName = response.Data.FirstName,
						LastName = response.Data.LastName,
						Title = response.Data.Title,
						Company = response.Data.Company,
						Email = response.Data.Email,
						PhoneCell = response.Data.PhoneCell,
						PhoneBusiness = response.Data.PhoneBusiness,
						Fax = response.Data.Fax,
						AddressLine1 = response.Data.AddressLine1,
						AddressLine2 = response.Data.AddressLine2,
						City = response.Data.City,
						State = response.Data.State,
						Zip = response.Data.Zip,
						IsActive = response.Data.IsActive
					},
					Items = await GetAllRelations(),
					MusicianIds = CreateListIdStringForMusician(response.Data.Musicians),
					PlatformIds = CreateListIdStringForPlatform(response.Data.Platforms),
					LabelIds = CreateListIdStringForLabels(response.Data.MusicLabels)
				}
			);
		}
		catch(Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return ServiceResult.CreateErrorInstance<ContactUpdateEntryViewModel>(ex.Message, ResponseCode.Error);
		}
	}

	public async Task<ServiceResult> UpdateEntry(ContactUpdateEntryViewModel model)
	{
		try
		{
			var request = new ContactUpdateModel()
			{
				Id = model.Form.Id,
				FirstName = model.Form.FirstName,
				LastName = model.Form.LastName,
				Title = model.Form.Title,
				Company = model.Form.Company,
				Email = model.Form.Email,
				PhoneCell = model.Form.PhoneCell,
				PhoneBusiness = model.Form.PhoneBusiness,
				Fax = model.Form.Fax,
				AddressLine1 = model.Form.AddressLine1,
				AddressLine2 = model.Form.AddressLine2,
				City = model.Form.City,
				State = model.Form.State,
				Zip = model.Form.Zip,
				IsActive = model.Form.IsActive,
				MusicianIds = CreateMusicianContactsList(model),
				PlatformIds = CreatePlatformContactsList(model),
				MusicLabelIds = CreateLabelsContactsList(model),
			};
			
			var response = await _contactClient.UpdateEntry(model.Form.Id, new UpdateCommandRequest<ContactUpdateModel> { Entry = request });
			return ServiceResult.CreateInstance(response);
		}
		catch(Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return ServiceResult.CreateErrorInstance(ex.Message, ResponseCode.Error);
		}
	}

	public async Task<ServiceResult> DeleteEntry(int id)
	{
		try
		{
			var response = await _contactClient.DeleteEntry(id);
			return ServiceResult.CreateInstance(response);
		}
		catch(Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return ServiceResult.CreateErrorInstance(ex.Message, ResponseCode.Error);
		}
	}

	private List<SelectListItem> CreateSelectListItem(List<MusicianReportModel> musicians, List<MusicLabelReportModel> musicLabels, List<PlatformReportModel> platforms)
	{
		var output = new List<SelectListItem>();
		
		foreach (var musician in musicians)
		{
			output.Add(new SelectListItem
			{
				Text = String.Concat(musician.Name, " (Musician)"),
				Value = musician.Id.ToString()
			});
		}
		
		foreach (var label in musicLabels)
		{
			output.Add(new SelectListItem
			{
				Text = String.Concat(label.Name, " (Label)"),
				Value = label.Id.ToString()
			});
		}
		
		foreach (var platform in platforms)
		{
			output.Add(new SelectListItem
			{
				Text = String.Concat(platform.Name, " (Platform)"),
				Value = platform.Id.ToString()
			});
		}

		return output;
	}

	private List<MusicianContactsCreateModel> CreateMusicianContactsList(ContactCreateEntryViewModel model)
	{
		if (model.MusicianIds == null)
		{
			return null;
		}
		
		var result = new List<MusicianContactsCreateModel>();

		foreach (var id in model.MusicianIds.Remove(0,1).Split(" "))
		{
			result.Add(new MusicianContactsCreateModel()
			{
				MusicianId = Convert.ToInt32(id)
			});
		}

		return result;
	}
	
	private List<MusicianContactsCreateModel> CreateMusicianContactsList(ContactUpdateEntryViewModel model)
	{
		if (model.MusicianIds == null)
		{
			return null;
		}
		
		var result = new List<MusicianContactsCreateModel>();

		foreach (var id in model.MusicianIds.Remove(0,1).Split(" "))
		{
			result.Add(new MusicianContactsCreateModel()
			{
				MusicianId = Convert.ToInt32(id)
			});
		}

		return result;
	}
	
	private List<PlatformContactsCreateModel> CreatePlatformContactsList(ContactCreateEntryViewModel model)
	{
		if (model.PlatformIds == null)
		{
			return null;
		}
		
		var result = new List<PlatformContactsCreateModel>();

		foreach (var id in model.PlatformIds.Remove(0,1).Split(" "))
		{
			result.Add(new PlatformContactsCreateModel()
			{
				PlatformId = Convert.ToInt32(id)
			});
		}

		return result;
	}
	
	private List<PlatformContactsCreateModel> CreatePlatformContactsList(ContactUpdateEntryViewModel model)
	{
		if (model.PlatformIds == null)
		{
			return null;
		}
		
		var result = new List<PlatformContactsCreateModel>();

		foreach (var id in model.PlatformIds.Remove(0,1).Split(" "))
		{
			result.Add(new PlatformContactsCreateModel()
			{
				PlatformId = Convert.ToInt32(id)
			});
		}

		return result;
	}
	
	private List<MusicLabelContactsCreateModel> CreateLabelsContactsList(ContactCreateEntryViewModel model)
	{
		if (model.LabelIds == null)
		{
			return null;
		}
		
		var result = new List<MusicLabelContactsCreateModel>();

		foreach (var id in model.LabelIds.Remove(0,1).Split(" "))
		{
			result.Add(new MusicLabelContactsCreateModel()
			{
				MusicLabelId = Convert.ToInt32(id)
			});
		}

		return result;
	}
	
	private List<MusicLabelContactsCreateModel> CreateLabelsContactsList(ContactUpdateEntryViewModel model)
	{
		if (model.LabelIds == null)
		{
			return null;
		}
		
		var result = new List<MusicLabelContactsCreateModel>();

		foreach (var id in model.LabelIds.Remove(0,1).Split(" "))
		{
			result.Add(new MusicLabelContactsCreateModel()
			{
				MusicLabelId = Convert.ToInt32(id)
			});
		}

		return result;
	}

	private async Task<List<SelectListItem>> GetAllRelations()
	{
		var musicians = (await _musicianClient.GetEntries(new EntriesQueryRequest { Offset = 0, Limit = Int32.MaxValue })).Data;
		var musicLabels = (await _musicLabelClient.GetEntries(new EntriesQueryRequest { Offset = 0, Limit = Int32.MaxValue })).Data;
		var platforms = (await _platformClient.GetEntries(new EntriesQueryRequest { Offset = 0, Limit = Int32.MaxValue })).Data;

		return CreateSelectListItem(musicians, musicLabels, platforms);
	}

	private string CreateListIdStringForMusician(IEnumerable<MusicianReportModel> musicians)
	{
		var result = String.Empty;

		foreach (var musician in musicians)
		{
			result += $" {musician.Id}";
		}

		return result;
	}
	
	private string CreateListIdStringForLabels(IEnumerable<MusicLabelReportModel> labels)
	{
		var result = String.Empty;

		foreach (var label in labels)
		{
			result += $" {label.Id}";
		}

		return result;
	}
	
	private string CreateListIdStringForPlatform(IEnumerable<PlatformReportModel> platforms)
	{
		var result = String.Empty;

		foreach (var platform in platforms)
		{
			result += $" {platform.Id}";
		}

		return result;
	}
}