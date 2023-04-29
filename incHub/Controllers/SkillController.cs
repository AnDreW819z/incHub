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
    public class SkillController : Controller
    {
        private ISkillRepository _skillRepository;
        private IMapper _mapper;
        public SkillController(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Skill>))]
        public IActionResult GetSkills()
        {
            var skills = _mapper.Map<List<SkillDto>>(_skillRepository.GetSkills());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(skills);
        }
        [HttpGet("{skillId}")]
        [ProducesResponseType(200, Type = typeof(Skill))]
        [ProducesResponseType(400)]
        public IActionResult GetSkill(int skillId)
        {
            if (!_skillRepository.SkillExists(skillId))
                return NotFound();
            var skill = _mapper.Map<SkillDto>(_skillRepository.GetSkill(skillId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(skill);
        }

        [HttpGet("user/{skillId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserBySkill(int skillId)
        {
            var users = _mapper.Map<List<UserDto>>(_skillRepository.GetUserBySkill(skillId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSkill([FromBody] SkillDto skillCreate)
        {
            if (skillCreate == null)
                return BadRequest(ModelState);

            var skill = _skillRepository.GetSkills()
                .Where(c => c.SkillDescription.Trim().ToUpper() == skillCreate.SkillDescription.Trim().ToUpper())
                .FirstOrDefault();

            if (skill != null)
            {
                ModelState.AddModelError("", "Skill already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var skillMap = _mapper.Map<Skill>(skillCreate);

            if (!_skillRepository.CreateSkill(skillMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
