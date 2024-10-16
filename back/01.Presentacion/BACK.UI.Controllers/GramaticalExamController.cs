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
    public class GramaticalExamController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public GramaticalExamController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/GramaticalExams
        [HttpGet("/api/GramaticalExams")]
        public IActionResult Get()
        {
            IEnumerable<GramaticalExamResource> gramaticalExamResource = _mapper.Map<IEnumerable<GramaticalExamResource>>(_service.GramaticalExamService.GetList());
            return Ok(gramaticalExamResource);
        }

        // GET /api/GramaticalExams/{ExamId}
        [HttpGet("/api/GramaticalExams/{ExamId}")]
        public IActionResult Get([FromRoute] int examId)
        {
            GramaticalExam gramaticalExam = _service.GramaticalExamService.Get(examId);
            if (gramaticalExam == null) return NotFound();

            GramaticalExamResource gramaticalExamResource = _mapper.Map<GramaticalExamResource>(gramaticalExam);
            return Ok(gramaticalExamResource);
        }

        // POST /api/GramaticalExams
        [HttpPost("/api/GramaticalExams")]
        public IActionResult Post([FromBody] GramaticalExamResource gramaticalExam)
        {
            if (gramaticalExam == null) return BadRequest();

            var e = _mapper.Map<GramaticalExam>(gramaticalExam);

            GramaticalExamResource gramaticalExamResource = _mapper.Map<GramaticalExamResource>(_service.GramaticalExamService.Add(e));
            return CreatedAtAction(nameof(Get), new { gramaticalExamResource.IdExam }, gramaticalExamResource);
        }

        // PUT /api/GramaticalExams/{IdExam}
        [HttpPut("/api/GramaticalExams/{IdExam}")]
        public IActionResult Put([FromRoute] int IdExam, [FromBody] GramaticalExamResource gramaticalExamResource)
        {
            if (gramaticalExamResource == null) return BadRequest();

            GramaticalExam gramaticalExamOld = _service.GramaticalExamService.Get(IdExam);
            if (gramaticalExamOld == null) return NotFound();

            _service.GramaticalExamService.Update(gramaticalExamOld, _mapper.Map<GramaticalExam>(gramaticalExamResource));
            return NoContent();
        }

        // DELETE /api/GramaticalExams/{IdExam}
        [HttpDelete("/api/GramaticalExams/{IdExam}")]
        public IActionResult Delete([FromRoute] int IdExam)
        {
            GramaticalExam gramaticalExam = _service.GramaticalExamService.Get(IdExam);
            if (gramaticalExam == null) return NotFound();

            _service.GramaticalExamService.Delete(gramaticalExam);
            return Ok();
        }
    }
}