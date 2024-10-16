 using BACK.CORE.Interfaces.Services;

namespace BACK.CORE.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IRoleService RoleService { get; }
        IExamQuestionService ExamQuestionService { get; }
        IQuestionService QuestionService { get; }

        IGrammarExamService GrammarExamService { get; }
        IExamService ExamService { get; }
        ITextService TextService { get; }

    }
}