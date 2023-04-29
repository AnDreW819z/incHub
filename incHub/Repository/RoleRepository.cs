using incHub.Data;
using incHub.Interfaces;
using incHub.Models;

namespace incHub.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }
        public bool RoleExists(int roleid)
        {
            return _context.Rols.Any(c => c.Id == roleid);
        }

        public bool CreateRole(Role role)
        {
            _context.Rols.Add(role);
            _context.SaveChanges();
            return Save();
        }

        public ICollection<Role> GetRols()
        {
            return _context.Rols.ToList();
        }

        public Role GetRole(int roleid)
        {
            return _context.Rols.Where(e => e.Id == roleid).FirstOrDefault();
        }

        public ICollection<Project> GetProjectByRole(int roleId)
        {
            return _context.ProjectRole.Where(e => e.RoleId == roleId).Select(c => c.Project).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
