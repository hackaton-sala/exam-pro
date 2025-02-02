﻿ using BACK.CORE.Interfaces.Repositories;
 using BACK.CORE.Interfaces.Services;

namespace BACK.CORE.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IRoleService RoleService { get; }
        IExamQuestionService ExamQuestionService { get; }
        IUseOfEnglishQuestionService UseOfEnglishQuestionService { get; }
        IReadingQuestionService ReadingQuestionService { get; }
        IWritingQuestionService WritingQuestionService { get; }
        ISpeakingQuestionService SpeakingQuestionService { get; }
        IListeningQuestionService ListeningQuestionService { get; }
        IQuestionService QuestionService { get; }

        IGrammarService GrammarService { get; }
        IExamService ExamService { get; }
        ITextService TextService { get; }

    }
}