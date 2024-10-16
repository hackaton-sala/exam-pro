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
    public class GrammarExamService : IGrammarExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrammarExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GrammarExam Add(GrammarExam grammarExam)
        {
            _unitOfWork.GrammarExams.Add(grammarExam);
            _unitOfWork.Complete();
            return grammarExam;
        }

       

        public void Delete(GrammarExam grammarExam)
        {
            _unitOfWork.GrammarExams.Remove(grammarExam);
            _unitOfWork.Complete();
        }

      


        public GrammarExam Get(int id)
        {
            return _unitOfWork.GrammarExams.Get(id);
        }

        public IEnumerable<GrammarExam> GetList()
        {
            return _unitOfWork.GrammarExams.GetAll();
        }

        public void Update(GrammarExam grammarExamOld, GrammarExam grammarExamNew)
        {
            _mapper.Map<GrammarExam, GrammarExam>(grammarExamNew, grammarExamOld);
            _unitOfWork.Complete();
        }

       

    }
}
