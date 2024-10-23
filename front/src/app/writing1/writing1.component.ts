import { Component } from '@angular/core';

@Component({
  selector: 'app-writing1',
  templateUrl: './writing1.component.html',
  styleUrls: ['./writing1.component.css']
})
export class Writing1Component {
  writingText: string = '';
  wordCounterText: string = 'Palabras: 0/170';
  wordLimit: number = 170;
  maxWords: number = 190;
  hasShownAlert: boolean = false;
  wordCount: number = 0;

  countWords(text: string): number {
    return text.trim().split(/\s+/).filter((word) => word.length > 0).length;
  }

  onInputChange(event: Event): void {
    const target = event.target as HTMLTextAreaElement;
    this.writingText = target.value; // Actualiza el valor de writingText
    this.wordCount = this.countWords(this.writingText);
    this.wordCounterText = `Palabras: ${this.wordCount}/${this.wordLimit}`;

    if (this.wordCount >= this.wordLimit && this.wordCount < this.maxWords) {
      // Cambiar color a verde (esto se manejará en CSS)
      this.hasShownAlert = false;
    } else if (this.wordCount >= this.maxWords && !this.hasShownAlert) {
      alert('¡Estás escribiendo demasiado, reduce tu writing!');
      this.hasShownAlert = true;
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault(); // Evita que el formulario se envíe y se recargue la página
    console.log('Writing submitted:', this.writingText);
    // Aquí puedes implementar la lógica para enviar el writing, por ejemplo, a un servidor
  }
}
