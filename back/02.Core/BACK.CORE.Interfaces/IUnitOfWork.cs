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
        IExamRepository Exams { get; }
        ITextRepository Texts { get; }

        int Complete();
        void Dispose();
    }
}