from openai import OpenAI

client = OpenAI(
  base_url = "https://integrate.api.nvidia.com/v1",
  api_key = "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"
)

completion = client.chat.completions.create(
  model="nvidia/llama-3.1-nemotron-70b-instruct",
  messages=[{"role":"user","content":"\nGenerate 5 questions for use of english part 1 examn b2. Only question, 4 options and the correct one"}],
  temperature=0.5,
  top_p=1,
  max_tokens=1024,
  stream=True
)

for chunk in completion:
  if chunk.choices[0].delta.content is not None:
    print(chunk.choices[0].delta.content, end="")

