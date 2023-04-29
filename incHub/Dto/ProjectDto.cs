using incHub.Models;

namespace incHub.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Task { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType Type { get; set; }

    }
}
