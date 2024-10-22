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
    public class UseOfEnglishQuestionService : IUseOfEnglishQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UseOfEnglishQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UseOfEnglishQuestion Add(UseOfEnglishQuestion useOfEnglishQuestion)
        {
            _unitOfWork.UseOfEnglishQuestions.Add(useOfEnglishQuestion);
            _unitOfWork.Complete();
            return useOfEnglishQuestion;
        }

        public void Delete(UseOfEnglishQuestion useOfEnglishQuestion)
        {
            _unitOfWork.UseOfEnglishQuestions.Remove(useOfEnglishQuestion);
            _unitOfWork.Complete();
        }

        public UseOfEnglishQuestion Get(int id)
        {
            return _unitOfWork.UseOfEnglishQuestions.Get(id);
        }

        public IEnumerable<UseOfEnglishQuestion> GetList()
        {
            return _unitOfWork.UseOfEnglishQuestions.GetAll();
        }

        public void Update(UseOfEnglishQuestion useOfEnglishQuestionOld, UseOfEnglishQuestion useOfEnglishQuestionNew)
        {
            _mapper.Map<UseOfEnglishQuestion, UseOfEnglishQuestion>(useOfEnglishQuestionNew, useOfEnglishQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
