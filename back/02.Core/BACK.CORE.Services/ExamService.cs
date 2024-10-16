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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Exam Add(Exam exam)
        {
            _unitOfWork.Exams.Add(exam);
            _unitOfWork.Complete();
            return exam;
        }

       

        public void Delete(Exam exam)
        {
            _unitOfWork.Exams.Remove(exam);
            _unitOfWork.Complete();
        }

      


        public Exam Get(int id)
        {
            return _unitOfWork.Exams.Get(id);
        }

        public IEnumerable<Exam> GetList()
        {
            return _unitOfWork.Exams.GetAll();
        }

        public void Update(Exam examOld, Exam examNew)
        {
            _mapper.Map<Exam, Exam>(examNew, examOld);
            _unitOfWork.Complete();
        }

       

    }
}
