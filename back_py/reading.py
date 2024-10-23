from importlib.resources import read_text
from openai import OpenAI
import re

# Inicializa el cliente con la URL base y la clave de API
client = OpenAI(
    base_url="https://integrate.api.nvidia.com/v1",
    api_key="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"  # Asegúrate de colocar tu API key aquí
)

# Define el mensaje que deseas enviar al modelo
prompt = "Generate a new text with gaps for a B2 level English exam with 6 questions and 4 options each. I want you to answer me in this format: \
 TEXT(in the gaps you put the numbers of the gap and a ______ but without 'gap') \
 Questions and Options\
    Gap1: \
Option A: ... \
Option B: ... \
Option C: ...  \
Option D: ... \
Solution: Option A: .."

completion = client.chat.completions.create(
    model="nvidia/llama-3.1-nemotron-70b-instruct",
    messages=[{"role": "user", "content": prompt}],
    temperature=0.5,
    top_p=1,
    max_tokens=800,  
    stream=True
)
response_parts = []
# Imprime la respuesta generada
for chunk in completion:
    if chunk.choices[0].delta.content is not None:
        response_parts.append(chunk.choices[0].delta.content)
        print(chunk.choices[0].delta.content, end="")

exam_text = ''.join(response_parts)
print("\nHOLA - muestro el texto de la variable")

text_content = [] #En esta variable se almacena el texto del reading con los huecos
text_content = re.search(r'\*\*TEXT\*\*(.*?)\*\*Questions and Options\*\*', exam_text, re.DOTALL).group(1).strip()
print(text_content)

#HASTA AQUÍ VA BIEN


matches= []
pattern = []
pattern = r'\*\*(\d+)\.\s*______\*\*\n(.*?)\*\*Solution:\*\* (Option [A-D]): (.*?) \('
matches = re.findall(pattern, exam_text, re.DOTALL)
print(matches)
# Guardar preguntas, opciones y soluciones en diccionarios
questions_options_solutions = {}

for match in matches:
    question_number = match[0]
    options = match[1].strip().split('\n')
    solution = match[2] + ": " + match[3]
    
    # Guardar en el diccionario usando el número de la pregunta como clave
    questions_options_solutions[question_number] = {
        'options': options,
        'solution': solution
    }

# Mostrar resultados
print("Texto:", text_content)
for q_num, data in questions_options_solutions.items():
    print(f"\nPregunta {q_num}:")
    print("Opciones:", data['options'])
    print("Solución:", data['solution'])
