using BACK.CORE.Entities;
using BACK.IL.Repository.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BACK.IL.Repository.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UseOfEnglishQuestion> UseOfEnglishQuestions { get; set; }
        public DbSet<WritingQuestion> WritingQuestions { get; set; }
        public DbSet<ReadingQuestion> ReadingQuestions { get; set; }
        public DbSet<SpeakingQuestion> SpeakingQuestions { get; set; }
        public DbSet<ListeningQuestion> ListeningQuestions { get; set; }
        public DbSet<GrammarExam> GrammarExams { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Text> Texts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ExamQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UseOfEnglishQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ReadingQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new WritingQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SpeakingQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ListeningQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new GrammarExamConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new TextConfiguration());
        }
    }
}