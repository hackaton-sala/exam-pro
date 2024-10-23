from flask import Flask, request, jsonify
from flask_cors import CORS
from openai import OpenAI
import re
from importlib.resources import read_text


# Inicializa Flask y configura CORS para permitir solicitudes desde localhost:4200
app = Flask(__name__)
CORS(app, resources={r"/*": {"origins": "http://localhost:4200"}})

# Inicializa OpenAI con la API proporcionada
client = OpenAI(
    base_url="https://integrate.api.nvidia.com/v1",
    api_key="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"
)

# Ruta para generar preguntas
@app.route('/generate-questions', methods=['POST'])
def generate_questions():

    try:
        # Llamada a OpenAI para generar el examen
        prompt = "Generate a new text with gaps for a B2 level English exam with 6 questions and 4 options each. I want you to answer me in this format: \
        TEXT(in the gaps you put the numbers of the gap and a ______ but without 'gap') \
        QUESTIONS & OPTIONS\
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
        text_content = re.search(r'\*\*TEXT\*\*(.*?)\*\*QUESTIONS & OPTIONS\*\*', exam_text, re.DOTALL).group(1).strip()
        print(text_content)

        #HASTA AQUÍ VA BIEN


        matches= []
        pattern = []
        pattern = r'\*\*(\d+)\.\s*______\*\*\n(.*?)\*\*Solution:\*\* (Option [A-D]): (.*?) \('
        matches = re.findall(pattern, exam_text, re.DOTALL)

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


        # Devolver el texto y las preguntas con opciones y soluciones como respuesta JSON
        return jsonify({
            "text": text_content,
            "questions": questions_options_solutions
        })

    except Exception as e:
        # Manejo de errores en la llamada a la API o procesamiento
        return jsonify({"error": str(e)}), 500

@app.route('/generate-feedback', methods=['POST'])
def generate_feedback():
    # Obtén el texto enviado en la solicitud POST
    data = request.json
    user_text = data.get('prompt')

    # Si no hay texto, devolver un error
    if not user_text:
        return jsonify({"error": "No text provided"}), 400
    print(user_text)
    # Construye el prompt con las instrucciones para corregir el texto
    prompt = 'From this article, correct the grammar and the structure according with the requirements of this type of essay in the B2 level exam.' + user_text

    try:
        # Llamada a OpenAI para generar el feedback
        completion = client.chat.completions.create(
            model="nvidia/llama-3.1-nemotron-70b-instruct",
            messages=[{"role": "user", "content": prompt}],
            temperature=0.5,
            top_p=1,
            max_tokens=800,  
            stream=True
        )

        # Procesa la respuesta en partes
        response_parts = []
        for chunk in completion:
            if chunk.choices[0].delta.content is not None:
                response_parts.append(chunk.choices[0].delta.content)

        # Une las partes en una sola cadena
        feedback = ''.join(response_parts)

        # Devuelve el feedback generado como respuesta
        return jsonify({"feedback": feedback})

    except Exception as e:
        # Manejo de errores en la llamada a la API
        return jsonify({"error": str(e)}), 500

# Ejecuta el servidor
if __name__ == '__main__':
    app.run(debug=True)
