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
    public class GrammarController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public GrammarController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("generar-examen-ia")]
        public async Task<IActionResult> GenerarExamenGrammarB2ConIA()
        {
            string a = "Generate 5 grammar questions for a B2 level English exam use of english part 1";

            var preguntas = await _service.GrammarService.CallOpenAiApi(a);
            return Ok(preguntas);
        }
    }
}