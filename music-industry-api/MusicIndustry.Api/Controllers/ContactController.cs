using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicIndustry.Api.Core.Clients;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Core.Models.Query.Contact;
using MusicIndustry.Api.Domain.Services.Contact;

namespace MusicIndustry.Api.Controllers;

[ApiController]
public class ContactController : ControllerBase, IContactClient
{
        private readonly IContactService _service;
        
        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet(RoutesHelper.Contact.Base)]
        [ProducesResponseType(200, Type = typeof(EntriesQueryResponse<ContactsReportModel>))]
        [ProducesDefaultResponseType]
        public async Task<EntriesQueryResponse<ContactsReportModel>> GetEntries([FromQuery] EntriesQueryRequest request)
        {
            return await _service.GetEntries<ContactsReportModel>(request);
        }

        [HttpPost(RoutesHelper.Contact.Base)]
        [ProducesResponseType(200, Type = typeof(CreateCommandResponse<int>))]
        [ProducesDefaultResponseType]
        public async Task<CreateCommandResponse<int>> CreateEntry([FromBody] CreateCommandRequest<ContactCreateModel> request)
        {
            return await _service.CreateEntry<ContactCreateModel, int>(request);
        }

        [HttpGet(RoutesHelper.Contact.Id)]
        [ProducesResponseType(200, Type = typeof(EntryQueryResponse<ContactReportModel>))]
        [ProducesDefaultResponseType]
        public async Task<EntryQueryResponse<ContactReportModel>> GetEntry([FromRoute] int id)
        {
            return await _service.GetEntry<ContactReportModel, int>(new EntryQueryRequest<int> { Id = id });
        }

        [HttpPut(RoutesHelper.Contact.Id)]
        [ProducesResponseType(200, Type = typeof(UpdateCommandResponse))]
        [ProducesDefaultResponseType]
        public async Task<UpdateCommandResponse> UpdateEntry([FromRoute] int id, [FromBody] UpdateCommandRequest<ContactUpdateModel> request)
        {
            return await _service.UpdateEntry<ContactUpdateModel, int>(request);
        }

        [HttpDelete(RoutesHelper.Contact.Id)]
        [ProducesResponseType(200, Type = typeof(DeleteCommandResponse))]
        [ProducesDefaultResponseType]
        public async Task<DeleteCommandResponse> DeleteEntry([FromRoute] int id)
        {
            return await _service.DeleteEntry(new DeleteCommandRequest<int> { Id = id });
        }
}