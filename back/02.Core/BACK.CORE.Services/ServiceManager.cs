using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace BACK.CORE.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            UserService = new UserService(_unitOfWork, _mapper);
            RoleService = new RoleService(_unitOfWork, _mapper);
            ExamQuestionService = new ExamQuestionService(_unitOfWork, _mapper);
            QuestionService = new QuestionService(_unitOfWork, _mapper);
            UseOfEnglishQuestionService = new UseOfEnglishQuestionService(_unitOfWork, _mapper);
            ReadingQuestionService = new ReadingQuestionService(_unitOfWork, _mapper);
            WritingQuestionService = new WritingQuestionService(_unitOfWork, _mapper);
            SpeakingQuestionService = new SpeakingQuestionService(_unitOfWork, _mapper);
            ListeningQuestionService = new ListeningQuestionService(_unitOfWork, _mapper);
            GrammarExamService = new GrammarExamService(_unitOfWork, _mapper);
            ExamService = new ExamService(_unitOfWork, _mapper);
            TextService = new TextService(_unitOfWork, _mapper);
        }
        public IUserService UserService { get; private set; }
        public IRoleService RoleService { get; private set; }
        public IGrammarExamService GrammarExamService {  get; private set; }
        public IExamQuestionService ExamQuestionService {  get; private set; }
        public IQuestionService QuestionService {  get; private set; }
        public IUseOfEnglishQuestionService UseOfEnglishQuestionService {  get; private set; }
        public IReadingQuestionService ReadingQuestionService {  get; private set; }
        public ISpeakingQuestionService SpeakingQuestionService {  get; private set; }
        public IListeningQuestionService ListeningQuestionService {  get; private set; }
        public IWritingQuestionService WritingQuestionService {  get; private set; }
        public IExamService ExamService {  get; private set; }
        public ITextService TextService {  get; private set; }
           
        }
     
}