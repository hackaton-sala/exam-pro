 using BACK.CORE.Interfaces.Services;

namespace BACK.CORE.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IRoleService RoleService { get; }
        IExamQuestionService ExamQuestionService { get; }

    }
}