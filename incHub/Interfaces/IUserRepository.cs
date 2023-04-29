using incHub.Dto;
using incHub.Models;

namespace incHub.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        ICollection<Project> GetUserOfProjects(int userId);
        ICollection<Skill> GetSkillByUser(int skillId);
        bool UserExists(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
