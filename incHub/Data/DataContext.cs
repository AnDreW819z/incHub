using incHub.Models;
using Microsoft.EntityFrameworkCore;

namespace incHub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserContactDetail> UserContactDetails { get; set; }
        public DbSet<Skill> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectRole>()
                .HasKey(pr => new {pr.RoleId, pr.ProjectId});
            modelBuilder.Entity<ProjectRole>()
                .HasOne(p => p.Project)
                .WithMany(pr => pr.ProjectRols)
                .HasForeignKey(p => p.ProjectId);
            modelBuilder.Entity<ProjectRole>()
                .HasOne(p => p.Role).
                WithMany(pr => pr.ProjectRols)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new {us.UserId, us.SkillId});
            modelBuilder.Entity<UserSkill>()
                .HasOne(s => s.Skill)
                .WithMany(us => us.UsersSkills)
                .HasForeignKey(s => s.SkillId);
            modelBuilder.Entity<UserSkill>()
                .HasOne(s => s.User)
                .WithMany(us => us.UserSkills)
                .HasForeignKey(s => s.UserId);

        }
    }
}
