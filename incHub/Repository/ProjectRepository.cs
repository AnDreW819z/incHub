using incHub.Data;
using incHub.Dto;
using incHub.Interfaces;
using incHub.Models;

namespace incHub.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateProject(Project project)
        {
            _context.Add(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _context.Remove(project);
            return Save();
        }

        public Project GetProject(int projectId)
        {
            return _context.Projects.Where(o => o.Id == projectId).FirstOrDefault();
        }

        public User GetUserOfProject(int projectId)
        {
            return _context.Projects.Where(o => o.Id == projectId).FirstOrDefault().User;
        }

        public ICollection<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

       

        public bool ProjectExists(int projectId)
        {
            return _context.Projects.Any(o => o.Id == projectId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProject(Project project)
        {
            _context.Update(project);
            return Save();
        }

    }
}
