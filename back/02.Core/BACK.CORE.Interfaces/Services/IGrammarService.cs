using BACK.CORE.Entities.New;
using BACK.CORE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Interfaces.Services
{
    public interface IGrammarService
    {
        Task<List<Question>> GenerarExamenGrammarB2ConIAAsync();
        Task<string> CallOpenAiApi(string prompt);
    }
}
