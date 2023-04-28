namespace incHub.Models
{
    public class Skill : BaseEntity
    {
        public string SkillDescription { get; set; }
        public ICollection<UserSkill> UsersSkills { get; set; }
    }
}
