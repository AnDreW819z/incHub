using incHub.Models;

namespace incHub.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<Role> GetRols();
        Role GetRole(int roleid);
        ICollection<Project> GetProjectByRole(int roleId);
        bool RoleExists(int roleid);
        bool CreateRole(Role role);
        bool Save();
    }
}
