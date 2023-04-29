namespace incHub.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Task { get; set; }
        public ProjectStatus Status { get; set; }
        public virtual User User { get; set; }
        public ProjectType Type { get; set; }
        public ICollection<ProjectRole> ProjectRols { get; set; }


    }
    public enum ProjectStatus
    {
        Open = 0,
        Running = 1,
        Postponed = 2,
        Сompleted = 3

    }

    public enum ProjectType
    {


        None = 0,
        WebApplication=1,
        Socity=2,
        MobileApplication=3,
        Desctop = 4,

    }
}
