import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-speaking1',
  templateUrl: './speaking1.component.html',
  styleUrls: ['./speaking1.component.css']
})
export class Speaking1Component {
  outputText: string = '';

  texts: string[] = [
    "The Last Train Home: Speak about a mysterious train that appears only at midnight and the passengers who board it.",
    "A Day in the Life of an Inanimate Object: Choose an everyday object and narrate its experiences from its perspective.",
    "Parallel Universe: Explore a world where one major historical event had a different outcome.",
    "The Forgotten Library: A character discovers a hidden library that contains books that can change reality.",
    "Letters to the Future: Talk about a series of letters from a character to their future self.",
    "A Lesson Learned the Hard Way: Share a personal story where you learned an important lesson.",
    "The Influence of a Mentor: Talk about someone who significantly impacted your life and the lessons they taught you.",
    "My Favorite Place: Describe a location that holds special meaning to you and why.",
    "The Impact of Technology on Relationships: Reflect on how technology has changed the way we connect with others.",
    "A Moment of Courage: Describe a time when you had to be brave, and what you learned from it.",
    "The Importance of Arts Education: Argue for or against the inclusion of arts in school curriculums.",
    "Social Media: A Blessing or a Curse?: Discuss the effects of social media on society today.",
    "Climate Change Action: Propose solutions individuals can take to combat climate change.",
    "The Future of Work: What will the workplace look like in 10 years? Discuss trends and changes.",
    "Universal Basic Income: Explore the pros and cons of implementing UBI in modern economies.",
    "A World Without Gravity: Imagine a society where gravity doesn’t exist and how people adapt.",
    "The Last Dragon: Tell a story about the last dragon in a world where they were once common.",
    "Time Travel Tourism: Describe a travel agency that offers trips to different time periods.",
    "Artificial Intelligence and Emotions: Explore the ethical implications of AI developing feelings.",
    "The Forgotten Gods: Talk about ancient gods trying to reclaim their worshippers in the modern world."
  ];
  @ViewChild('audioReceptor', { static: false }) audioReceptor!: ElementRef<HTMLAudioElement>;
  @ViewChild('sendButton', { static: false }) sendButton!: ElementRef<HTMLButtonElement>;

  mediaRecorder!: MediaRecorder;
  audioChunks: Blob[] = [];
  audioBlob!: Blob;
  isRecording = false;
  isAudioAvailable = false;
  recordingButtonText = 'Iniciar grabación';

  constructor() { }

  // Función para alternar la grabación
  async toggleRecording() {
    if (!this.isRecording) {
      try {
        const stream = await navigator.mediaDevices.getUserMedia({ audio: true });
        this.mediaRecorder = new MediaRecorder(stream);

        this.mediaRecorder.ondataavailable = (event) => {
          this.audioChunks.push(event.data);
        };

        this.mediaRecorder.onstop = () => {
          this.audioBlob = new Blob(this.audioChunks, { type: 'audio/wav' });
          const audioUrl = URL.createObjectURL(this.audioBlob);
          this.audioReceptor.nativeElement.src = audioUrl;

          this.isAudioAvailable = true; // Habilitar el botón de enviar
          this.sendButton.nativeElement.disabled = false; // Desbloquear el botón de enviar

          this.audioChunks = []; // Limpiar para la siguiente grabación
        };

        this.mediaRecorder.start();
        this.recordingButtonText = 'Detener grabación';
        this.isRecording = true;
      } catch (error) {
        console.error('Error al acceder al micrófono:', error);
      }
    } else {
      this.mediaRecorder.stop();
      this.recordingButtonText = 'Iniciar grabación';
      this.isRecording = false;
    }
  }

  // Función para enviar el audio grabado
  sendAudio() {
    if (this.audioBlob) {
      const formData = new FormData();
      formData.append('audio', this.audioBlob, 'grabacion.wav');

      fetch('TU_URL_DEL_SERVIDOR_AQUI', {
        method: 'POST',
        body: formData,
      })
        .then(response => {
          if (response.ok) {
            alert('El audio ha sido enviado exitosamente.');
          } else {
            alert('Error al enviar el audio.');
          }
        })
        .catch(error => {
          console.error('Error al enviar el audio:', error);
          alert('Error de red al intentar enviar el audio.');
        });
    }
  }

  copyText() {
    // Implementar la lógica para copiar texto
  }

  generateText() {
    const randomIndex = Math.floor(Math.random()* this.texts.length);
    this.outputText = this.texts[randomIndex];
  }
}
