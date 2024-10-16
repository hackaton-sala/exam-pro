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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Question Add(Question question)
        {
            _unitOfWork.Questions.Add(question);
            _unitOfWork.Complete();
            return question;
        }

        public void Delete(Question question)
        {
            _unitOfWork.Questions.Remove(question);
            _unitOfWork.Complete();
        }

        public Question Get(int id)
        {
            return _unitOfWork.Questions.Get(id);
        }

        public IEnumerable<Question> GetList()
        {
            return _unitOfWork.Questions.GetAll();
        }

        public void Update(Question questionOld, Question questionNew)
        {
            _mapper.Map<Question, Question>(questionNew, questionOld);
            _unitOfWork.Complete();
        }

        
    }
}
