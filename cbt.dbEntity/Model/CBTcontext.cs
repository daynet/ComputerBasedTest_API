namespace cbt.dbEntity.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CBTcontext : DbContext
    {
        public CBTcontext()
            : base("name=CBTcontext")
        {
        }

        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<CorrectAnswer> CorrectAnswer { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<LoginActivity> LoginActivity { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<OptionType> OptionType { get; set; }
        public virtual DbSet<PublishedQuestion> PublishedQuestion { get; set; }
        public virtual DbSet<QuestionBank> QuestionBank { get; set; }
        public virtual DbSet<QuestionOption> QuestionOption { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Signup> Signup { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TestResult> TestResult { get; set; }
        public virtual DbSet<TestSetup> TestSetup { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<TestCategory> TestCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginActivity>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionBank>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<Signup>()
                .Property(e => e.ExamDate)
                .IsUnicode(false);
        }
    }
}
