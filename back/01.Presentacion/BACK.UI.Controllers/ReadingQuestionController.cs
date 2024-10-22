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
    public class ReadingQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ReadingQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/ReadingQuestions
        [HttpGet("/api/ReadingQuestions")]
        public IActionResult Get()
        {
            IEnumerable<ReadingQuestionResource> ReadingQuestionResource = _mapper.Map<IEnumerable<ReadingQuestionResource>>(_service.ReadingQuestionService.GetList());
            return Ok(ReadingQuestionResource);
        }

        // GET /api/ReadingQuestions/{ReadingQuestionId}
        [HttpGet("/api/ReadingQuestions/{ReadingQuestionId}")]
        public IActionResult Get([FromRoute] int ReadingQuestionId)
        {
            ReadingQuestion ReadingQuestion = _service.ReadingQuestionService.Get(ReadingQuestionId);
            if (ReadingQuestion == null) return NotFound();

            ReadingQuestionResource ReadingQuestionResource = _mapper.Map<ReadingQuestionResource>(ReadingQuestion);
            return Ok(ReadingQuestionResource);
        }

        // POST /api/ReadingQuestions
        [HttpPost("/api/ReadingQuestions")]
        public IActionResult Post([FromBody] ReadingQuestionResource ReadingQuestion)
        {
            if (ReadingQuestion == null) return BadRequest();

            var e = _mapper.Map<ReadingQuestion>(ReadingQuestion);

            ReadingQuestionResource ReadingQuestionResource = _mapper.Map<ReadingQuestionResource>(_service.ReadingQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { ReadingQuestionResource.ReadingQuestionId }, ReadingQuestionResource);
        }

        // PUT /api/ReadingQuestions/{ReadingQuestionId}
        [HttpPut("/api/ReadingQuestions/{ReadingQuestionId}")]
        public IActionResult Put([FromRoute] int ReadingQuestionId, [FromBody] ReadingQuestionResource ReadingQuestionResource)
        {
            if (ReadingQuestionResource == null) return BadRequest();

            ReadingQuestion ReadingQuestionOld = _service.ReadingQuestionService.Get(ReadingQuestionId);
            if (ReadingQuestionOld == null) return NotFound();

            _service.ReadingQuestionService.Update(ReadingQuestionOld, _mapper.Map<ReadingQuestion>(ReadingQuestionResource));
            return NoContent();
        }

        // DELETE /api/ReadingQuestions/{ReadingQuestionId}
        [HttpDelete("/api/ReadingQuestions/{ReadingQuestionId}")]
        public IActionResult Delete([FromRoute] int ReadingQuestionId)
        {
            ReadingQuestion ReadingQuestion = _service.ReadingQuestionService.Get(ReadingQuestionId);
            if (ReadingQuestion == null) return NotFound();

            _service.ReadingQuestionService.Delete(ReadingQuestion);
            return Ok();
        }
    }
}