using incHub.Data;
using incHub.Dto;
using incHub.Interfaces;
using incHub.Models;

namespace incHub.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Where(o => o.Id == userId).FirstOrDefault();
        }

        public ICollection<Project> GetUserOfProjects (int userId)
        {
            return _context.Projects.Where(p => p.User.Id == userId).ToList();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ICollection<Skill> GetSkillByUser(int userId)
        {

            I
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(o => o.Id == userId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

    }
}
