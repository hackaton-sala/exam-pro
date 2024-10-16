using BACK.CORE.Interfaces.Repositories;

namespace BACK.CORE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IExamQuestionRepository ExamQuestions { get; }
        IGramaticalExamRepository GramaticalExams { get; }
        IQuestionRepository Questions { get; }

        int Complete();
        void Dispose();
    }
}