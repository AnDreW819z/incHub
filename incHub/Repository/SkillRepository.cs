using incHub.Data;
using incHub.Interfaces;
using incHub.Models;

namespace incHub.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _context;
        public SkillRepository(DataContext context)
        {
            _context = context;
        }
        public bool SkillExists(int skillid)
        {
            return _context.Skills.Any(c => c.Id == skillid);
        }

        public bool CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return Save();
        }

        public ICollection<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }

        public Skill GetSkill(int skillid)
        {
            return _context.Skills.Where(e => e.Id == skillid).FirstOrDefault();
        }

        public ICollection<User> GetUserBySkill(int skillId)
        {
            return _context.UserSkills.Where(e => e.SkillId == skillId).Select(c => c.User).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
