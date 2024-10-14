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
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        // GET /api/Users
        [HttpGet("/api/Users")]
        public IActionResult Get()
        {
            IEnumerable<UserResource> UserResource = _mapper.Map<IEnumerable<UserResource>>(_service.UserService.GetList());
            return Ok(UserResource);
        }

        // GET /api/Users/{UserId}
        [HttpGet("/api/Users/{UserId}")]
        public IActionResult Get([FromRoute] int UserId)
        {
            User User = _service.UserService.Get(UserId);
            if (User == null) return NotFound();

            UserResource UserResource = _mapper.Map<UserResource>(User);
            return Ok(UserResource);
        }

        // POST /api/Users
        [HttpPost("/api/Users")]
        public IActionResult Post([FromBody] UserResource User)
        {
            if (User == null) return BadRequest();

            var e = _mapper.Map<User>(User);

            UserResource UserResource = _mapper.Map<UserResource>(_service.UserService.Add(e));
            return CreatedAtAction(nameof(Get), new { UserResource.UserId }, UserResource);
        }

        // PUT /api/Users/{UserId}
        [HttpPut("/api/Users/{UserId}")]
        public IActionResult Put([FromRoute] int UserId, [FromBody] UserResource UserResource)
        {
            if (UserResource == null) return BadRequest();

            User UserOld = _service.UserService.Get(UserId);
            if (UserOld == null) return NotFound();

            _service.UserService.Update(UserOld, _mapper.Map<User>(UserResource));
            return NoContent();
        }

        // DELETE /api/Users/{UserId}
        [HttpDelete("/api/Users/{UserId}")]
        public IActionResult Delete([FromRoute] int UserId)
        {
            User User = _service.UserService.Get(UserId);
            if (User == null) return NotFound();

            _service.UserService.Delete(User);
            return Ok();
        }
    }
}