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
    public class UseOfEnglishQuestionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public UseOfEnglishQuestionController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/UseOfEnglishQuestions
        [HttpGet("/api/UseOfEnglishQuestions")]
        public IActionResult Get()
        {
            IEnumerable<UseOfEnglishQuestionResource> useOfEnglishQuestionResource = _mapper.Map<IEnumerable<UseOfEnglishQuestionResource>>(_service.UseOfEnglishQuestionService.GetList());
            return Ok(useOfEnglishQuestionResource);
        }

        // GET /api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}
        [HttpGet("/api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}")]
        public IActionResult Get([FromRoute] int UseOfEnglishQuestionId)
        {
            UseOfEnglishQuestion useOfEnglishQuestion = _service.UseOfEnglishQuestionService.Get(UseOfEnglishQuestionId);
            if (useOfEnglishQuestion == null) return NotFound();

            UseOfEnglishQuestionResource UseOfEnglishQuestionResource = _mapper.Map<UseOfEnglishQuestionResource>(useOfEnglishQuestion);
            return Ok(UseOfEnglishQuestionResource);
        }

        // POST /api/UseOfEnglishQuestions
        [HttpPost("/api/UseOfEnglishQuestions")]
        public IActionResult Post([FromBody] UseOfEnglishQuestionResource useOfEnglishQuestion)
        {
            if (useOfEnglishQuestion == null) return BadRequest();

            var e = _mapper.Map<UseOfEnglishQuestion>(useOfEnglishQuestion);

            UseOfEnglishQuestionResource useOfEnglishQuestionResource = _mapper.Map<UseOfEnglishQuestionResource>(_service.UseOfEnglishQuestionService.Add(e));
            return CreatedAtAction(nameof(Get), new { useOfEnglishQuestionResource.UseOfEnglishQuestionId }, useOfEnglishQuestionResource);
        }

        // PUT /api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}
        [HttpPut("/api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}")]
        public IActionResult Put([FromRoute] int UseOfEnglishQuestionId, [FromBody] UseOfEnglishQuestionResource useOfEnglishQuestionResource)
        {
            if (useOfEnglishQuestionResource == null) return BadRequest();

            UseOfEnglishQuestion UseOfEnglishQuestionOld = _service.UseOfEnglishQuestionService.Get(UseOfEnglishQuestionId);
            if (UseOfEnglishQuestionOld == null) return NotFound();

            _service.UseOfEnglishQuestionService.Update(UseOfEnglishQuestionOld, _mapper.Map<UseOfEnglishQuestion>(useOfEnglishQuestionResource));
            return NoContent();
        }

        // DELETE /api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}
        [HttpDelete("/api/UseOfEnglishQuestions/{UseOfEnglishQuestionId}")]
        public IActionResult Delete([FromRoute] int useOfEnglishQuestionId)
        {
            UseOfEnglishQuestion useOfEnglishQuestion = _service.UseOfEnglishQuestionService.Get(useOfEnglishQuestionId);
            if (useOfEnglishQuestion == null) return NotFound();

            _service.UseOfEnglishQuestionService.Delete(useOfEnglishQuestion);
            return Ok();
        }
    }
}