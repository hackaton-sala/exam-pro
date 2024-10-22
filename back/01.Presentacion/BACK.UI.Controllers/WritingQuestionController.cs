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
    public class WritingQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public WritingQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/WritingQuestions
        [HttpGet("/api/WritingQuestions")]
        public IActionResult Get()
        {
            IEnumerable<WritingQuestionResource> WritingQuestionResource = _mapper.Map<IEnumerable<WritingQuestionResource>>(_service.WritingQuestionService.GetList());
            return Ok(WritingQuestionResource);
        }

        // GET /api/WritingQuestions/{WritingQuestionId}
        [HttpGet("/api/WritingQuestions/{WritingQuestionId}")]
        public IActionResult Get([FromRoute] int WritingQuestionId)
        {
            WritingQuestion WritingQuestion = _service.WritingQuestionService.Get(WritingQuestionId);
            if (WritingQuestion == null) return NotFound();

            WritingQuestionResource WritingQuestionResource = _mapper.Map<WritingQuestionResource>(WritingQuestion);
            return Ok(WritingQuestionResource);
        }

        // POST /api/WritingQuestions
        [HttpPost("/api/WritingQuestions")]
        public IActionResult Post([FromBody] WritingQuestionResource WritingQuestion)
        {
            if (WritingQuestion == null) return BadRequest();

            var e = _mapper.Map<WritingQuestion>(WritingQuestion);

            WritingQuestionResource WritingQuestionResource = _mapper.Map<WritingQuestionResource>(_service.WritingQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { WritingQuestionResource.WritingQuestionId }, WritingQuestionResource);
        }

        // PUT /api/WritingQuestions/{WritingQuestionId}
        [HttpPut("/api/WritingQuestions/{WritingQuestionId}")]
        public IActionResult Put([FromRoute] int WritingQuestionId, [FromBody] WritingQuestionResource WritingQuestionResource)
        {
            if (WritingQuestionResource == null) return BadRequest();

            WritingQuestion WritingQuestionOld = _service.WritingQuestionService.Get(WritingQuestionId);
            if (WritingQuestionOld == null) return NotFound();

            _service.WritingQuestionService.Update(WritingQuestionOld, _mapper.Map<WritingQuestion>(WritingQuestionResource));
            return NoContent();
        }

        // DELETE /api/WritingQuestions/{WritingQuestionId}
        [HttpDelete("/api/WritingQuestions/{WritingQuestionId}")]
        public IActionResult Delete([FromRoute] int WritingQuestionId)
        {
            WritingQuestion WritingQuestion = _service.WritingQuestionService.Get(WritingQuestionId);
            if (WritingQuestion == null) return NotFound();

            _service.WritingQuestionService.Delete(WritingQuestion);
            return Ok();
        }
    }
}