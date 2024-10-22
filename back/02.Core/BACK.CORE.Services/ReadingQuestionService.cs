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
    public class ReadingQuestionService : IReadingQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReadingQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ReadingQuestion Add(ReadingQuestion readingQuestion)
        {
            _unitOfWork.ReadingQuestions.Add(readingQuestion);
            _unitOfWork.Complete();
            return readingQuestion;
        }

        public void Delete(ReadingQuestion readingQuestion)
        {
            _unitOfWork.ReadingQuestions.Remove(readingQuestion);
            _unitOfWork.Complete();
        }

        public ReadingQuestion Get(int id)
        {
            return _unitOfWork.ReadingQuestions.Get(id);
        }

        public IEnumerable<ReadingQuestion> GetList()
        {
            return _unitOfWork.ReadingQuestions.GetAll();
        }

        public void Update(ReadingQuestion readingQuestionOld, ReadingQuestion readingQuestionNew)
        {
            _mapper.Map<ReadingQuestion, ReadingQuestion>(readingQuestionNew, readingQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
