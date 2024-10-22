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
    public class WritingQuestionService : IWritingQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WritingQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WritingQuestion Add(WritingQuestion writingQuestion)
        {
            _unitOfWork.WritingQuestions.Add(writingQuestion);
            _unitOfWork.Complete();
            return writingQuestion;
        }

        public void Delete(WritingQuestion writingQuestion)
        {
            _unitOfWork.WritingQuestions.Remove(writingQuestion);
            _unitOfWork.Complete();
        }

        public WritingQuestion Get(int id)
        {
            return _unitOfWork.WritingQuestions.Get(id);
        }

        public IEnumerable<WritingQuestion> GetList()
        {
            return _unitOfWork.WritingQuestions.GetAll();
        }

        public void Update(WritingQuestion writingQuestionOld, WritingQuestion writingQuestionNew)
        {
            _mapper.Map<WritingQuestion, WritingQuestion>(writingQuestionNew, writingQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
