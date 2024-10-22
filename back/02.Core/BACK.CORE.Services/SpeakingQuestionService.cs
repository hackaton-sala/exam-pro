using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;
using BACK.CORE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Services
{
    public class SpeakingQuestionService : ISpeakingQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpeakingQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SpeakingQuestion Add(SpeakingQuestion SpeakingQuestion)
        {
            _unitOfWork.SpeakingQuestions.Add(SpeakingQuestion);
            _unitOfWork.Complete();
            return SpeakingQuestion;
        }

        public void Delete(SpeakingQuestion SpeakingQuestion)
        {
            _unitOfWork.SpeakingQuestions.Remove(SpeakingQuestion);
            _unitOfWork.Complete();
        }

        public SpeakingQuestion Get(int id)
        {
            return _unitOfWork.SpeakingQuestions.Get(id);
        }

        public IEnumerable<SpeakingQuestion> GetList()
        {
            return _unitOfWork.SpeakingQuestions.GetAll();
        }

        public void Update(SpeakingQuestion SpeakingQuestionOld, SpeakingQuestion SpeakingQuestionNew)
        {
            _mapper.Map<SpeakingQuestion, SpeakingQuestion>(SpeakingQuestionNew, SpeakingQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
