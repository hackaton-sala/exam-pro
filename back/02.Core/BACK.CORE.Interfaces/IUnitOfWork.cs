using BACK.CORE.Interfaces.Repositories;

namespace BACK.CORE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IExamQuestionRepository ExamQuestions { get; }
        IGrammarExamRepository GrammarExams { get; }
        IQuestionRepository Questions { get; }
        IUseOfEnglishQuestionRepository UseOfEnglishQuestions { get; }
        IReadingQuestionRepository ReadingQuestions { get; }
        IWritingQuestionRepository WritingQuestions { get; }
        IExamRepository Exams { get; }
        ITextRepository Texts { get; }

        int Complete();
        void Dispose();
    }
}