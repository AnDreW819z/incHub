using incHub.Dto;
using incHub.Models;

namespace incHub.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        ICollection<Project> GetUserOfProjects(int projectId);
        ICollection<Skill> GetUserBySkill(int skillId);
        bool UserExists(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
