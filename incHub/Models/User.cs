namespace incHub.Models
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public DateTime Birth { get; set; }
        public byte[]? Photo { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<Project>? Project { get; set; }
    }
}
