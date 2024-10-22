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
    public class ListeningQuestionService : IListeningQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListeningQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ListeningQuestion Add(ListeningQuestion ListeningQuestion)
        {
            _unitOfWork.ListeningQuestions.Add(ListeningQuestion);
            _unitOfWork.Complete();
            return ListeningQuestion;
        }

        public void Delete(ListeningQuestion ListeningQuestion)
        {
            _unitOfWork.ListeningQuestions.Remove(ListeningQuestion);
            _unitOfWork.Complete();
        }

        public ListeningQuestion Get(int id)
        {
            return _unitOfWork.ListeningQuestions.Get(id);
        }

        public IEnumerable<ListeningQuestion> GetList()
        {
            return _unitOfWork.ListeningQuestions.GetAll();
        }

        public void Update(ListeningQuestion ListeningQuestionOld, ListeningQuestion ListeningQuestionNew)
        {
            _mapper.Map<ListeningQuestion, ListeningQuestion>(ListeningQuestionNew, ListeningQuestionOld);
            _unitOfWork.Complete();
        }

        
    }
}
