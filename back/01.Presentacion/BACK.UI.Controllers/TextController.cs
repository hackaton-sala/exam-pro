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
    public class TextController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public TextController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/Texts
        [HttpGet("/api/Texts")]
        public IActionResult Get()
        {
            IEnumerable<TextResource> textResource = _mapper.Map<IEnumerable<TextResource>>(_service.TextService.GetList());
            return Ok(textResource);
        }

        // GET /api/Texts/{TextId}
        [HttpGet("/api/Texts/{TextId}")]
        public IActionResult Get([FromRoute] int TextId)
        {
            Text text = _service.TextService.Get(TextId);
            if (text == null) return NotFound();

            TextResource textResource = _mapper.Map<TextResource>(text);
            return Ok(textResource);
        }

        // POST /api/Texts
        [HttpPost("/api/Texts")]
        public IActionResult Post([FromBody] TextResource text)
        {
            if (text == null) return BadRequest();

            var e = _mapper.Map<Text>(text);

            TextResource textResource = _mapper.Map<TextResource>(_service.TextService.Add(e));
            return CreatedAtAction(nameof(Get), new { textResource.TextId }, textResource);
        }

        // PUT /api/Texts/{IdText}
        [HttpPut("/api/Texts/{IdText}")]
        public IActionResult Put([FromRoute] int IdText, [FromBody] TextResource textResource)
        {
            if (textResource == null) return BadRequest();

            Text textOld = _service.TextService.Get(IdText);
            if (textOld == null) return NotFound();

            _service.TextService.Update(textOld, _mapper.Map<Text>(textResource));
            return NoContent();
        }

        // DELETE /api/Texts/{IdText}
        [HttpDelete("/api/Texts/{IdText}")]
        public IActionResult Delete([FromRoute] int IdText)
        {
            Text text = _service.TextService.Get(IdText);
            if (text == null) return NotFound();

            _service.TextService.Delete(text);
            return Ok();
        }
    }
}