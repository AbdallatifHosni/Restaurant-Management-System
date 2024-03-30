using E_Learning_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Management_System.Data
{
    public class ApplicatioDbContext:DbContext
    {
        public ApplicatioDbContext(DbContextOptions options )
            :base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<Instructor>(DB =>
            {
                DB.HasOne(e => e.Account)
                .WithOne(e => e.Instructor)
                .HasForeignKey<Account>(e =>e.InstructorIDFK)
                .OnDelete(DeleteBehavior.NoAction);
            });
              

        }

        internal Task RemoveAsync(Quiz? item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////
        /// </summary>
        public virtual DbSet<Account>  Accounts{ get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public  virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<Quiz> Quizzes  { get; set; }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Duration> Durations { get; set; } 
        public DbSet<Content> Contents { get; set; } 
        public DbSet<Learner> Learners { get; set; } 
        public DbSet<Feedback> Feedbacks { get; set; }


    }
}
