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
    public class GramaticalExamService : IGramaticalExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GramaticalExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GramaticalExam Add(GramaticalExam gramaticalExam)
        {
            _unitOfWork.GramaticalExams.Add(gramaticalExam);
            _unitOfWork.Complete();
            return gramaticalExam;
        }

       

        public void Delete(GramaticalExam gramaticalExam)
        {
            _unitOfWork.GramaticalExams.Remove(gramaticalExam);
            _unitOfWork.Complete();
        }

      


        public GramaticalExam Get(int id)
        {
            return _unitOfWork.GramaticalExams.Get(id);
        }

        public IEnumerable<GramaticalExam> GetList()
        {
            return _unitOfWork.GramaticalExams.GetAll();
        }

        public void Update(GramaticalExam gramaticalExamOld, GramaticalExam gramaticalExamNew)
        {
            _mapper.Map<GramaticalExam, GramaticalExam>(gramaticalExamNew, gramaticalExamOld);
            _unitOfWork.Complete();
        }

       

    }
}
