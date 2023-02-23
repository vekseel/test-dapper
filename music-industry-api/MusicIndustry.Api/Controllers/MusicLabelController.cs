﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MusicIndustry.Api.Core.Clients;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Domain.Services;

namespace MusicIndustry.Api.Controllers
{
    [ApiController]
    public class MusicLabelController : ControllerBase, IMusicLabelClient
    {
        private readonly IMusicLabelService _service;
        public MusicLabelController(IMusicLabelService service)
        {
            _service = service;
        }

        [HttpGet(RoutesHelper.MusicLabel.Base)]
        [ProducesResponseType(200, Type = typeof(EntriesQueryResponse<MusicLabelReportModel>))]
        [ProducesDefaultResponseType]
        public async Task<EntriesQueryResponse<MusicLabelReportModel>> GetEntries([FromQuery] EntriesQueryRequest request)
        {
            return await _service.GetEntries<MusicLabelReportModel>(request);
        }

        [HttpPost(RoutesHelper.MusicLabel.Base)]
        [ProducesResponseType(200, Type = typeof(CreateCommandResponse<int>))]
        [ProducesDefaultResponseType]
        public async Task<CreateCommandResponse<int>> CreateEntry([FromBody] CreateCommandRequest<MusicLabelCreateModel> request)
        {
            return await _service.CreateEntry<MusicLabelCreateModel, int>(request);
        }

        [HttpGet(RoutesHelper.MusicLabel.Id)]
        [ProducesResponseType(200, Type = typeof(EntryQueryResponse<MusicLabelReportModel>))]
        [ProducesDefaultResponseType]
        public async Task<EntryQueryResponse<MusicLabelReportModel>> GetEntry([FromRoute] int id)
        {
            return await _service.GetEntry<MusicLabelReportModel, int>(new EntryQueryRequest<int> { Id = id });
        }

        [HttpPut(RoutesHelper.MusicLabel.Id)]
        [ProducesResponseType(200, Type = typeof(UpdateCommandResponse))]
        [ProducesDefaultResponseType]
        public async Task<UpdateCommandResponse> UpdateEntry([FromRoute] int id, [FromBody] UpdateCommandRequest<MusicLabelUpdateModel> request)
        {
            return await _service.UpdateEntry<MusicLabelUpdateModel, int>(request);
        }

        [HttpDelete(RoutesHelper.MusicLabel.Id)]
        [ProducesResponseType(200, Type = typeof(DeleteCommandResponse))]
        [ProducesDefaultResponseType]
        public async Task<DeleteCommandResponse> DeleteEntry([FromRoute] int id)
        {
            return await _service.DeleteEntry(new DeleteCommandRequest<int> { Id = id });
        }
    }
}
