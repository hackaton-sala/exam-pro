from openai import OpenAI
import re

# Inicializa el cliente con la URL base y la clave de API
client = OpenAI(
    base_url="https://integrate.api.nvidia.com/v1",
    api_key="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"  # Asegúrate de colocar tu API key aquí
)
user_text='A great time to spend your free time!  \
Football is my favourite leisure free time activity. It is a sport that allows you to be fit, socialize with people and relax your mind from studies or work.\
I started playing football when I was 5 years old, so I have been playing it for 16 years. At first, my father used to take me to the training, so he allowed me to practice this sport and gives me the passion to have fun with it. \
I enjoyed football so much because of many facts. Firstly, it makes me healthier than if I don’t do any sport, and, I also become more relaxed before I play it. Secondly, this sport is so passionate, and I love this as I feel adrenaline that gives me strength to give more to my team and play better. \
I recommended you trying to play football, specially if you are young, because if you train hard, you will be a better player and you will enjoy the sport as I do, which would allow you to feel relaxed and have a lot of new experiences.'


# Define el mensaje que deseas enviar al modelo
prompt = 'From this article, correct the grammar and the structure according with the requirements of this type of essay in the B2 level exam.' + user_text

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


feedback = ''.join(response_parts)
print('\nVARIABLE FEEDBACK')
print(feedback)