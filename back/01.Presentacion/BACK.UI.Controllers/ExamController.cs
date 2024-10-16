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
    public class ExamController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ExamController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/Exams
        [HttpGet("/api/Exams")]
        public IActionResult Get()
        {
            IEnumerable<ExamResource> examResource = _mapper.Map<IEnumerable<ExamResource>>(_service.ExamService.GetList());
            return Ok(examResource);
        }

        // GET /api/Exams/{ExamId}
        [HttpGet("/api/Exams/{ExamId}")]
        public IActionResult Get([FromRoute] int examId)
        {
            Exam exam = _service.ExamService.Get(examId);
            if (exam == null) return NotFound();

            ExamResource examResource = _mapper.Map<ExamResource>(exam);
            return Ok(examResource);
        }

        // POST /api/Exams
        [HttpPost("/api/Exams")]
        public IActionResult Post([FromBody] ExamResource exam)
        {
            if (exam == null) return BadRequest();

            var e = _mapper.Map<Exam>(exam);

            ExamResource examResource = _mapper.Map<ExamResource>(_service.ExamService.Add(e));
            return CreatedAtAction(nameof(Get), new { examResource.ExamId }, examResource);
        }

        // PUT /api/Exams/{IdExam}
        [HttpPut("/api/Exams/{IdExam}")]
        public IActionResult Put([FromRoute] int IdExam, [FromBody] ExamResource ExamResource)
        {
            if (ExamResource == null) return BadRequest();

            Exam examOld = _service.ExamService.Get(IdExam);
            if (examOld == null) return NotFound();

            _service.ExamService.Update(examOld, _mapper.Map<Exam>(ExamResource));
            return NoContent();
        }

        // DELETE /api/Exams/{IdExam}
        [HttpDelete("/api/Exams/{IdExam}")]
        public IActionResult Delete([FromRoute] int IdExam)
        {
            Exam exam = _service.ExamService.Get(IdExam);
            if (exam == null) return NotFound();

            _service.ExamService.Delete(exam);
            return Ok();
        }
    }
}