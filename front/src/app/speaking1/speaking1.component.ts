import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-speaking1',
  templateUrl: './speaking1.component.html',
  styleUrls: ['./speaking1.component.css']
})
export class Speaking1Component {
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
    // Implementar la lógica para generar un nuevo texto
  }
}
