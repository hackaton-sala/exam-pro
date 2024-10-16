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
    public class GrammarExamController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public GrammarExamController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/GramaticalExams
        [HttpGet("/api/GramaticalExams")]
        public IActionResult Get()
        {
            IEnumerable<GrammarExamResource> gramaticalExamResource = _mapper.Map<IEnumerable<GrammarExamResource>>(_service.GrammarExamService.GetList());
            return Ok(gramaticalExamResource);
        }

        // GET /api/GramaticalExams/{ExamId}
        [HttpGet("/api/GramaticalExams/{ExamId}")]
        public IActionResult Get([FromRoute] int examId)
        {
            GrammarExam grammarExam = _service.GrammarExamService.Get(examId);
            if (grammarExam == null) return NotFound();

            GrammarExamResource grammarExamResource = _mapper.Map<GrammarExamResource>(grammarExam);
            return Ok(grammarExamResource);
        }

        // POST /api/GramaticalExams
        [HttpPost("/api/GramaticalExams")]
        public IActionResult Post([FromBody] GrammarExamResource grammarExam)
        {
            if (grammarExam == null) return BadRequest();

            var e = _mapper.Map<GrammarExam>(grammarExam);

            GrammarExamResource grammarExamResource = _mapper.Map<GrammarExamResource>(_service.GrammarExamService.Add(e));
            return CreatedAtAction(nameof(Get), new { grammarExamResource.IdExam }, grammarExamResource);
        }

        // PUT /api/GramaticalExams/{IdExam}
        [HttpPut("/api/GramaticalExams/{IdExam}")]
        public IActionResult Put([FromRoute] int IdExam, [FromBody] GrammarExamResource grammarExamResource)
        {
            if (grammarExamResource == null) return BadRequest();

            GrammarExam grammarExamOld = _service.GrammarExamService.Get(IdExam);
            if (grammarExamOld == null) return NotFound();

            _service.GrammarExamService.Update(grammarExamOld, _mapper.Map<GrammarExam>(grammarExamResource));
            return NoContent();
        }

        // DELETE /api/GramaticalExams/{IdExam}
        [HttpDelete("/api/GramaticalExams/{IdExam}")]
        public IActionResult Delete([FromRoute] int IdExam)
        {
            GrammarExam grammarExam = _service.GrammarExamService.Get(IdExam);
            if (grammarExam == null) return NotFound();

            _service.GrammarExamService.Delete(grammarExam);
            return Ok();
        }
    }
}