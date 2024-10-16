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
    public class TextService : ITextService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TextService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Text Add(Text text)
        {
            _unitOfWork.Texts.Add(text);
            _unitOfWork.Complete();
            return text;
        }

       

        public void Delete(Text text)
        {
            _unitOfWork.Texts.Remove(text);
            _unitOfWork.Complete();
        }

      


        public Text Get(int id)
        {
            return _unitOfWork.Texts.Get(id);
        }

        public IEnumerable<Text> GetList()
        {
            return _unitOfWork.Texts.GetAll();
        }

        public void Update(Text textOld, Text textNew)
        {
            _mapper.Map<Text, Text>(textNew, textOld);
            _unitOfWork.Complete();
        }

       

    }
}
