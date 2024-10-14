using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Queries.OData;
using BACK.CORE.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BACK.UI.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public RoleController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/roles
        [HttpGet("/api/roles")]
        public IActionResult Get()
        {
            IEnumerable<RoleResource> roleResource = _mapper.Map<IEnumerable<RoleResource>>(_service.RoleService.GetList());
            return Ok(roleResource);
        }

        // GET /api/roles/{roleId}
        [HttpGet("/api/roles/{roleId}")]
        public IActionResult Get([FromRoute] int roleId)
        {
            Role role = _service.RoleService.Get(roleId);
            if (role == null) return NotFound();

            RoleResource roleResource = _mapper.Map<RoleResource>(role);
            return Ok(roleResource);
        }

        // POST /api/roles
        [HttpPost("/api/roles")]
        public IActionResult Post([FromBody] RoleResource role)
        {
            if (role == null) return BadRequest();

            RoleResource roleResource = _mapper.Map<RoleResource>(_service.RoleService.Add(_mapper.Map<Role>(role)));
            return CreatedAtAction(nameof(Get), new { roleResource.RoleId }, roleResource);
        }

        // PUT /api/roles/{roleId}
        [HttpPut("/api/roles/{roleId}")]
        public IActionResult Put([FromRoute] int roleId, [FromBody] RoleResource RoleResource)
        {
            if (RoleResource == null) return BadRequest();

            Role roleOld = _service.RoleService.Get(roleId);
            if (roleOld == null) return NotFound();

            _service.RoleService.Update(roleOld, _mapper.Map<Role>(RoleResource));
            return NoContent();
        }

        // DELETE /api/roles/{roleId}
        [HttpDelete("/api/roles/{roleId}")]
        public IActionResult Delete([FromRoute] int roleId)
        {
            Role role = _service.RoleService.Get(roleId);
            if (role == null) return NotFound();

            _service.RoleService.Delete(role);
            return Ok();
        }
    }
}