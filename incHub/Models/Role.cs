namespace incHub.Models
{
    public class Role : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<ProjectRole> ProjectRols { get; set; }
    }
}
