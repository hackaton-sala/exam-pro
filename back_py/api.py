from flask import Flask, jsonify, request
from flask_cors import CORS  # Importar CORS
from transformers import pipeline

app = Flask(__name__)
CORS(app)
# Cargamos el modelo de transformers
pipe = pipeline("text-generation", model="nvidia/Llama-3.1-Nemotron-70B-Instruct-HF")

# Endpoint para generar preguntas
@app.route('/generate-questions', methods=['POST'])
def generate_questions():
    data = request.json
    prompt = data.get('prompt', '')
    messages = [
        {"role": "user", "content": prompt},
    ]
    pipe = pipeline("text-generation", model="nvidia/Llama-3.1-Nemotron-70B-Instruct-HF")

    # Generar preguntas usando el prompt
    result = pipe(messages)
    response_text = result[0]['generated_text']

    # Retornamos el resultado en formato JSON
    return jsonify({"questions": response_text})

if __name__ == '__main__':
    app.run(debug=True)
