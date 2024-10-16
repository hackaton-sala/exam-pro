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
    public class QuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public QuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/Questions
        [HttpGet("/api/Questions")]
        public IActionResult Get()
        {
            IEnumerable<QuestionResource> questionResource = _mapper.Map<IEnumerable<QuestionResource>>(_service.QuestionService.GetList());
            return Ok(questionResource);
        }

        // GET /api/Questions/{QuestionId}
        [HttpGet("/api/Questions/{QuestionId}")]
        public IActionResult Get([FromRoute] int questionId)
        {
            Question question = _service.QuestionService.Get(questionId);
            if (question == null) return NotFound();

            QuestionResource questionResource = _mapper.Map<QuestionResource>(question);
            return Ok(questionResource);
        }

        // POST /api/Questions
        [HttpPost("/api/Questions")]
        public IActionResult Post([FromBody] QuestionResource question)
        {
            if (question == null) return BadRequest();

            var e = _mapper.Map<Question>(question);

            QuestionResource questionResource = _mapper.Map<QuestionResource>(_service.QuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { questionResource.QuestionId }, questionResource);
        }

        // PUT /api/Questions/{QuestionId}
        [HttpPut("/api/Questions/{QuestionId}")]
        public IActionResult Put([FromRoute] int questionId, [FromBody] QuestionResource questionResource)
        {
            if (questionResource == null) return BadRequest();

            Question questionOld = _service.QuestionService.Get(questionId);
            if (questionOld == null) return NotFound();

            _service.QuestionService.Update(questionOld, _mapper.Map<Question>(questionResource));
            return NoContent();
        }

        // DELETE /api/Questions/{QuestionId}
        [HttpDelete("/api/Questions/{QuestionId}")]
        public IActionResult Delete([FromRoute] int questionId)
        {
            Question question = _service.QuestionService.Get(questionId);
            if (question == null) return NotFound();

            _service.QuestionService.Delete(question);
            return Ok();
        }
    }
}