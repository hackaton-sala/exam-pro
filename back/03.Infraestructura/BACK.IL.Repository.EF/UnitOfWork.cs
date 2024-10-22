using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Repositories;
using BACK.IL.Repository.EF.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.IL.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            ExamQuestions = new ExamQuestionRepository(_context); 
            Questions = new QuestionRepository(_context); 
            UseOfEnglishQuestions = new UseOfEnglishQuestionRepository(_context); 
            ReadingQuestions = new ReadingQuestionRepository(_context); 
            WritingQuestions = new WritingQuestionRepository(_context); 
            SpeakingQuestions = new SpeakingQuestionRepository(_context); 
            ListeningQuestions = new ListeningQuestionRepository(_context); 
            GrammarExams = new GrammarExamRepository(_context);
            Exams = new ExamRepository(_context);
            Texts = new TextRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IExamQuestionRepository ExamQuestions { get; private set; }
        public IQuestionRepository Questions { get; private set; }
        public IUseOfEnglishQuestionRepository UseOfEnglishQuestions { get; private set; }
        public IReadingQuestionRepository ReadingQuestions { get; private set; }
        public IWritingQuestionRepository WritingQuestions { get; private set; }
        public ISpeakingQuestionRepository SpeakingQuestions { get; private set; }
        public IListeningQuestionRepository ListeningQuestions { get; private set; }
        public IGrammarExamRepository GrammarExams { get; private set; }
        public IExamRepository Exams { get; private set; }
        public ITextRepository Texts { get; private set; }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }catch (Exception ex)
            {
                if(ex.InnerException.GetType().Equals(typeof(SqlException)))
                {
                    SqlException sqlEx = (SqlException)ex.InnerException;
                    switch(sqlEx.Number)
                    {
                        case 547:
                            throw new ArgumentException("5000 - Se ha producido un conflicto relacionado con este registro", sqlEx);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    
}
