using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicIndustry.UI.Helpers;
using MusicIndustry.UI.Models;
using MusicIndustry.UI.Models.Contact;
using MusicIndustry.UI.Services.Contact;

namespace MusicIndustry.UI.Controllers;

public class ContactController : BaseController
{
		private readonly IContactService _service;
		private readonly PagingAppSettings _pagingAppSettings;

		protected override string MainRoute() => UIRoutesHelper.Contact.GetEntries.GetUrl();

		public ContactController(IContactService service, PagingAppSettings pagingAppSettings)
		{
			_service = service ?? ThrowHelper.NullArgument<IContactService>();
			_pagingAppSettings = pagingAppSettings ?? ThrowHelper.NullArgument<PagingAppSettings>();
		}

		[HttpGet(UIRoutesHelper.Contact.GetEntries.PATH)]
		public async Task<IActionResult> GetEntries(int offset = 0, int? limit = null)
		{
			var result = await _service.GetEntries(offset, limit ?? _pagingAppSettings.DefaultPageLimit);
			return GetResult(result, true);
		}

		[HttpGet(UIRoutesHelper.Contact.CreateEntry.PATH)]
		public async Task<IActionResult> CreateEntry()
		{
			var result = await _service.GetCreateEntryViewModel();
			return GetResult(result, false);
		}

		[HttpPost(UIRoutesHelper.Contact.CreateEntry.PATH)]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateEntry(ViewModel<ContactCreateEntryViewModel> model)
		{
			if(model?.Data?.Form == null)
			{
				return BadRequest();
			}

			if(ModelState.IsValid)
			{
				var result = await _service.CreateEntry(model.Data);
				if(result.Status.Success)
				{
					return GetRedirectResult(result);
				}
				TempData["Error"] = result.Status.ErrorMessage;
			}

			var newResult = await _service.GetCreateEntryViewModel();
			newResult.ViewModel.Data.Form = model.Data.Form;
			return GetResult(newResult, false);
		}

		[HttpGet(UIRoutesHelper.Contact.UpdateEntry.PATH)]
		public async Task<IActionResult> UpdateEntry([FromRoute] int id)
		{
			var result = await _service.GetUpdateEntryViewModel(id);
			return GetResult(result, false);
		}

		[HttpPost(UIRoutesHelper.Contact.UpdateEntry.PATH)]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateEntry([FromRoute] int id, ViewModel<ContactUpdateEntryViewModel> model)
		{
			if(model?.Data?.Form == null)
			{
				return BadRequest();
			}

			if(ModelState.IsValid)
			{
				model.Data.Form.Id = id;
				var result = await _service.UpdateEntry(model.Data);
				if(result.Status.Success)
				{
					return GetRedirectResult(result);
				}
				TempData["Error"] = result.Status.ErrorMessage;
			}

			var newResult = await _service.GetUpdateEntryViewModel(id);
			newResult.ViewModel.Data.Form = model.Data.Form;
			return GetResult(newResult, false);
		}

		[HttpPost(UIRoutesHelper.Contact.DeleteEntry.PATH)]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteEntry([FromRoute] int id)
		{
			var result = await _service.DeleteEntry(id);
			return GetRedirectResult(result);
		}
}
