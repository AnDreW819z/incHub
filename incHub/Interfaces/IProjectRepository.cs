using incHub.Dto;
using incHub.Models;

namespace incHub.Interfaces
{
    public interface IProjectRepository
    {
        ICollection<Project> GetProjects();
        Project GetProject(int userId);
        User GetUserOfProject(int projectId);
        bool ProjectExists(int projectId);
        bool CreateProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
        bool Save();
    }
}
