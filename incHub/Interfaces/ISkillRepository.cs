using incHub.Models;

namespace incHub.Interfaces
{
    public interface ISkillRepository
    {
        ICollection<Skill> GetSkills();
        Skill GetSkill(int skillid);
        ICollection<User> GetUserBySkill(int skillId);
        bool SkillExists(int skillid);
        bool CreateSkill(Skill skill);
        bool Save();
    }
}
