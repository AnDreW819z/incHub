namespace incHub.Models
{
    public class ProjectRole 
    {
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Project Project { get; set; }
    }
}
