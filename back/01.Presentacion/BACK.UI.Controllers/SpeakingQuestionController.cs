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
    public class SpeakingQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public SpeakingQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/SpeakingQuestions
        [HttpGet("/api/SpeakingQuestions")]
        public IActionResult Get()
        {
            IEnumerable<SpeakingQuestionResource> SpeakingQuestionResource = _mapper.Map<IEnumerable<SpeakingQuestionResource>>(_service.SpeakingQuestionService.GetList());
            return Ok(SpeakingQuestionResource);
        }

        // GET /api/SpeakingQuestions/{SpeakingQuestionId}
        [HttpGet("/api/SpeakingQuestions/{SpeakingQuestionId}")]
        public IActionResult Get([FromRoute] int SpeakingQuestionId)
        {
            SpeakingQuestion SpeakingQuestion = _service.SpeakingQuestionService.Get(SpeakingQuestionId);
            if (SpeakingQuestion == null) return NotFound();

            SpeakingQuestionResource SpeakingQuestionResource = _mapper.Map<SpeakingQuestionResource>(SpeakingQuestion);
            return Ok(SpeakingQuestionResource);
        }

        // POST /api/SpeakingQuestions
        [HttpPost("/api/SpeakingQuestions")]
        public IActionResult Post([FromBody] SpeakingQuestionResource SpeakingQuestion)
        {
            if (SpeakingQuestion == null) return BadRequest();

            var e = _mapper.Map<SpeakingQuestion>(SpeakingQuestion);

            SpeakingQuestionResource SpeakingQuestionResource = _mapper.Map<SpeakingQuestionResource>(_service.SpeakingQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { SpeakingQuestionResource.SpeakingQuestionId }, SpeakingQuestionResource);
        }

        // PUT /api/SpeakingQuestions/{SpeakingQuestionId}
        [HttpPut("/api/SpeakingQuestions/{SpeakingQuestionId}")]
        public IActionResult Put([FromRoute] int SpeakingQuestionId, [FromBody] SpeakingQuestionResource SpeakingQuestionResource)
        {
            if (SpeakingQuestionResource == null) return BadRequest();

            SpeakingQuestion SpeakingQuestionOld = _service.SpeakingQuestionService.Get(SpeakingQuestionId);
            if (SpeakingQuestionOld == null) return NotFound();

            _service.SpeakingQuestionService.Update(SpeakingQuestionOld, _mapper.Map<SpeakingQuestion>(SpeakingQuestionResource));
            return NoContent();
        }

        // DELETE /api/SpeakingQuestions/{SpeakingQuestionId}
        [HttpDelete("/api/SpeakingQuestions/{SpeakingQuestionId}")]
        public IActionResult Delete([FromRoute] int SpeakingQuestionId)
        {
            SpeakingQuestion SpeakingQuestion = _service.SpeakingQuestionService.Get(SpeakingQuestionId);
            if (SpeakingQuestion == null) return NotFound();

            _service.SpeakingQuestionService.Delete(SpeakingQuestion);
            return Ok();
        }
    }
}