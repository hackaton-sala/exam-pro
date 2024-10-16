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
    public class ExamQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ExamQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/ExamQuestions
        [HttpGet("/api/ExamQuestions")]
        public IActionResult Get()
        {
            IEnumerable<ExamQuestionResource> examQuestionResource = _mapper.Map<IEnumerable<ExamQuestionResource>>(_service.ExamQuestionService.GetList());
            return Ok(examQuestionResource);
        }

        // GET /api/ExamQuestions/{QuestionId}
        [HttpGet("/api/ExamQuestions/{QuestionId}")]
        public IActionResult Get([FromRoute] int examQuestionId)
        {
            ExamQuestion examQuestion = _service.ExamQuestionService.Get(examQuestionId);
            if (examQuestion == null) return NotFound();

            ExamQuestionResource examQuestionResource = _mapper.Map<ExamQuestionResource>(examQuestion);
            return Ok(examQuestionResource);
        }

        // POST /api/ExamQuestions
        [HttpPost("/api/ExamQuestions")]
        public IActionResult Post([FromBody] ExamQuestionResource examQuestion)
        {
            if (examQuestion == null) return BadRequest();

            var e = _mapper.Map<ExamQuestion>(examQuestion);

            ExamQuestionResource examQuestionResource = _mapper.Map<ExamQuestionResource>(_service.ExamQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { examQuestionResource.QuestionId }, examQuestionResource);
        }

        // PUT /api/ExamQuestions/{ExamQuestionId}
        [HttpPut("/api/ExamQuestions/{QuestionId}")]
        public IActionResult Put([FromRoute] int examQuestionId, [FromBody] ExamQuestionResource examQuestionResource)
        {
            if (examQuestionResource == null) return BadRequest();

            ExamQuestion examQuestionOld = _service.ExamQuestionService.Get(examQuestionId);
            if (examQuestionOld == null) return NotFound();

            _service.ExamQuestionService.Update(examQuestionOld, _mapper.Map<ExamQuestion>(examQuestionResource));
            return NoContent();
        }

        // DELETE /api/ExamQuestions/{ExamQuestionId}
        [HttpDelete("/api/ExamQuestions/{QuestionId}")]
        public IActionResult Delete([FromRoute] int questionId)
        {
            ExamQuestion examQuestion = _service.ExamQuestionService.Get(questionId);
            if (examQuestion == null) return NotFound();

            _service.ExamQuestionService.Delete(examQuestion);
            return Ok();
        }
    }
}