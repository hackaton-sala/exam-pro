from flask import Flask, request, jsonify
from flask_cors import CORS
from openai import OpenAI

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
    # Obtén el prompt enviado en la solicitud POST
    data = request.json
    prompt = data.get('prompt')
    print(prompt)
    # Si no hay prompt, devolver un error
    if not prompt:
        return jsonify({"error": "No prompt provided"}), 400

    # Llamada a OpenAI para generar las preguntas
    completion = client.chat.completions.create(
        model="nvidia/llama-3.1-nemotron-70b-instruct",
        messages=[{"role": "user", "content": prompt}],
        temperature=0.5,
        top_p=1,
        max_tokens=1024,
        stream=False  # Cambiado a False para obtener la respuesta completa
    )

    # Procesa la respuesta y extrae las preguntas
    generated_text = completion.choices[0].message.content
    
    # Devuelve las preguntas generadas como respuesta
    return jsonify({"questions": generated_text})

# Ejecuta el servidor
if __name__ == '__main__':
    app.run(debug=True)
