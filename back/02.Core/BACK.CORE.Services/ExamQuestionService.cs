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
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ExamQuestion Add(ExamQuestion examQuestion)
        {
            _unitOfWork.ExamQuestions.Add(examQuestion);
            _unitOfWork.Complete();
            return examQuestion;
        }

        public void Delete(ExamQuestion examQuestion)
        {
            _unitOfWork.ExamQuestions.Remove(examQuestion);
            _unitOfWork.Complete();
        }

        public ExamQuestion Get(int id)
        {
            return _unitOfWork.ExamQuestions.Get(id);
        }

        public IEnumerable<ExamQuestion> GetList()
        {
            return _unitOfWork.ExamQuestions.GetAll();
        }

        public void Update(ExamQuestion examQuestionOld, ExamQuestion examQuestionNew)
        {
            _mapper.Map<ExamQuestion, ExamQuestion>(examQuestionNew, examQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
