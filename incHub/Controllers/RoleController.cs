using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using incHub.Dto;
using incHub.Interfaces;
using incHub.Models;
using incHub.Repository;

namespace incHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private IRoleRepository _roleRepository;
        private IMapper _mapper;
        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Role>))]
        public IActionResult GetRols()
        {
            var rols = _mapper.Map<List<RoleDto>>(_roleRepository.GetRols());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(rols);
        }
        [HttpGet("{roleId}")]
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        public IActionResult GetRole(int roleId)
        {
            if (!_roleRepository.RoleExists(roleId))
                return NotFound();
            var role = _mapper.Map<RoleDto>(_roleRepository.GetRole(roleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(role);
        }

        [HttpGet("project/{roleId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Project>))]
        [ProducesResponseType(400)]
        public IActionResult GetProjectByRole(int roleId)
        {
            var projects = _mapper.Map<List<ProjectDto>>(_roleRepository.GetProjectByRole(roleId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(projects);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRole([FromBody] RoleDto roleCreate)
        {
            if (roleCreate == null)
                return BadRequest(ModelState);

            var role = _roleRepository.GetRols()
                .Where(c => c.Description.Trim().ToUpper() == roleCreate.Description.Trim().ToUpper())
                .FirstOrDefault();

            if (role != null)
            {
                ModelState.AddModelError("", "Role already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roleMap = _mapper.Map<Role>(roleCreate);

            if (!_roleRepository.CreateRole(roleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
