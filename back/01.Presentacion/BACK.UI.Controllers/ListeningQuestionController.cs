using AutoMapper;
using BACK.CORE.Resources;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Queries.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BACK.UI.Controllers
{
    [ApiController]
    public class ListeningQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ListeningQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/ListeningQuestions
        [HttpGet("/api/ListeningQuestions")]
        public IActionResult Get()
        {
            IEnumerable<ListeningQuestionResource> ListeningQuestionResource = _mapper.Map<IEnumerable<ListeningQuestionResource>>(_service.ListeningQuestionService.GetList());
            return Ok(ListeningQuestionResource);
        }

        // GET /api/ListeningQuestions/{ListeningQuestionId}
        [HttpGet("/api/ListeningQuestions/{ListeningQuestionId}")]
        public IActionResult Get([FromRoute] int ListeningQuestionId)
        {
            ListeningQuestion ListeningQuestion = _service.ListeningQuestionService.Get(ListeningQuestionId);
            if (ListeningQuestion == null) return NotFound();

            ListeningQuestionResource ListeningQuestionResource = _mapper.Map<ListeningQuestionResource>(ListeningQuestion);
            return Ok(ListeningQuestionResource);
        }

        // POST /api/ListeningQuestions
        [HttpPost("/api/ListeningQuestions")]
        public IActionResult Post([FromBody] ListeningQuestionResource ListeningQuestion)
        {
            if (ListeningQuestion == null) return BadRequest();

            var e = _mapper.Map<ListeningQuestion>(ListeningQuestion);

            ListeningQuestionResource ListeningQuestionResource = _mapper.Map<ListeningQuestionResource>(_service.ListeningQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { ListeningQuestionResource.ListeningQuestionId }, ListeningQuestionResource);
        }

        // PUT /api/ListeningQuestions/{ListeningQuestionId}
        [HttpPut("/api/ListeningQuestions/{ListeningQuestionId}")]
        public IActionResult Put([FromRoute] int ListeningQuestionId, [FromBody] ListeningQuestionResource ListeningQuestionResource)
        {
            if (ListeningQuestionResource == null) return BadRequest();

            ListeningQuestion ListeningQuestionOld = _service.ListeningQuestionService.Get(ListeningQuestionId);
            if (ListeningQuestionOld == null) return NotFound();

            _service.ListeningQuestionService.Update(ListeningQuestionOld, _mapper.Map<ListeningQuestion>(ListeningQuestionResource));
            return NoContent();
        }

        // DELETE /api/ListeningQuestions/{ListeningQuestionId}
        [HttpDelete("/api/ListeningQuestions/{ListeningQuestionId}")]
        public IActionResult Delete([FromRoute] int ListeningQuestionId)
        {
            ListeningQuestion ListeningQuestion = _service.ListeningQuestionService.Get(ListeningQuestionId);
            if (ListeningQuestion == null) return NotFound();

            _service.ListeningQuestionService.Delete(ListeningQuestion);
            return Ok();
        }
    }
}