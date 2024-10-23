using AutoMapper;
using BACK.CORE.Entities.New;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;
using BACK.CORE.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Services
{
    public class GrammarService : IGrammarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private static readonly HttpClient client = new HttpClient();

        public GrammarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> CallOpenAiApi(string prompt)
        {
            var apiKey = "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"; // Sustituye esto por tu clave API

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",  // Puedes usar "gpt-3.5-turbo" o "davinci" para mejores resultados
                    prompt = prompt,
                    max_tokens = 500,  // Puedes ajustar según la longitud deseada
                    temperature = 0.7  // Controla la creatividad de las respuestas
                };

                var jsonBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
                    return jsonResponse.choices[0].text;
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
        }
        public async Task<List<Question>> GenerarExamenGrammarB2ConIAAsync()
        {
            string apiKey = "";
            // Configurar la llamada a la API de IA (por ejemplo, OpenAI GPT)
            var client = new HttpClient();
            var requestBody = new
            {
                model = "gpt-3.5-turbo", // Puedes usar otro modelo si lo deseas
                messages = new[]
            {
                new { role = "user", content = "Generate 5 grammar questions for a B2 level English exam use of english part 1" }
            },
                max_tokens = 1 // Ajusta el número de tokens según sea necesario
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Obtener la respuesta de la IA
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            // Aquí deberías transformar el resultado en preguntas
            List<Question> preguntasGeneradas = ParsearPreguntasDeIA(result);
            return preguntasGeneradas;
        }

        private List<Question> ParsearPreguntasDeIA(string jsonResult)
        {
            // Aquí convertirás la respuesta de la IA a objetos Pregunta
            // Esta función es un ejemplo básico, dependerá del formato de respuesta de la IA
            List<Question> preguntas = new List<Question>();

            // Suponiendo que la respuesta viene en formato JSON
            var iaResponse = JsonConvert.DeserializeObject<IaResponseModel>(jsonResult);

            foreach (var preguntaIA in iaResponse.Preguntas)
            {
                var pregunta = new Question
                {
                    QuestionText = preguntaIA.Texto,
                    Options = preguntaIA.Opciones.Select(o => new Option { OptionText = o }).ToList(),
                    EnglishLevel = "B2",
                    ExamPart = "Use of English Part 1",
                    ExamType = "Grammar"
                };

                preguntas.Add(pregunta);
            }

            return preguntas;
        }

        public class IaResponseModel
        {
            public List<PreguntaGenerada> Preguntas { get; set; }
        }

        public class PreguntaGenerada
        {
            public string Texto { get; set; }
            public List<string> Opciones { get; set; }
        }

        public class OpenAiRequest
        {
            public string Model { get; set; } = "gpt-3.5-turbo";
            public string Prompt { get; set; }
            public int MaxTokens { get; set; } = 100;
            public double Temperature { get; set; } = 0.7;
        }

        public class OpenAiResponse
        {
            public string Id { get; set; }
            public string Object { get; set; }
            public int Created { get; set; }
            public string Model { get; set; }
            public Choice[] Choices { get; set; }
        }

        public class Choice
        {
            public string Text { get; set; }
            public int Index { get; set; }
        }

    }
}
