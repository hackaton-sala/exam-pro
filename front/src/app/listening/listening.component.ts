import { Component } from '@angular/core';

@Component({
  selector: 'app-listening',
  templateUrl: './listening.component.html',
  styleUrl: './listening.component.css'
})
export class ListeningComponent {
  correctAnswers: string[] = ['dawn', 'horrible', 'concept', 'expressions', 'encouragement', 'master’s', 'summer', 'friends', 'fitness', 'stepping stone'];

  // Función para reproducir el audio
  public playAudio(){
    console.log("play audio")
    const audio = document.getElementById('audioPlayer') as HTMLAudioElement;
    console.log(audio);
    if (audio) {
      audio.play();
    }
  }

  // Función para comprobar las respuestas
  checkAnswers(): void {
    const userAnswers: string[] = [];

    // Recolectamos los valores de los inputs por su ID
    for (let i = 1; i <= this.correctAnswers.length; i++) {
      const inputElement = document.getElementById(`word${i}`) as HTMLInputElement;
      if (inputElement) {
        userAnswers.push(inputElement.value.toLowerCase());
      }
    }

    // Comparamos las respuestas del usuario con las correctas
    let correctCount = 0;
    userAnswers.forEach((answer, index) => {
      if (answer === this.correctAnswers[index]) {
        correctCount++;
      }
    });

    // Mostramos el resultado
    const resultMessage = document.getElementById('result') as HTMLElement;
    if (resultMessage) {
      if (correctCount === this.correctAnswers.length) {
        resultMessage.textContent = '¡Todas las respuestas son correctas!';
        resultMessage.classList.add('correct');
        resultMessage.classList.remove('incorrect');
      } else {
        resultMessage.textContent = `Tienes ${correctCount} de ${this.correctAnswers.length} respuestas correctas.`;
        resultMessage.classList.add('incorrect');
        resultMessage.classList.remove('correct');
      }
    }
  }
}
