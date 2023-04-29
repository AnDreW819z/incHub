using incHub.Dto;
using incHub.Models;

namespace incHub.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        ICollection<Project> GetProjectOfUser(int userId);
        ICollection<Skill> GetSkillByUser(int userId);
        bool UserExists(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
