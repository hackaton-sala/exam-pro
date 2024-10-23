import { Component } from '@angular/core';

@Component({
  selector: 'app-writing1',
  templateUrl: './writing1.component.html',
  styleUrls: ['./writing1.component.css']
})
export class Writing1Component {
  writingText: string = '';
  outputText: string = ''; // Añade esta línea para almacenar el texto generado
  wordCounterText: string = 'Palabras: 0/170';
  wordLimit: number = 170;
  maxWords: number = 190;
  hasShownAlert: boolean = false;
  wordCount: number = 0;

  // Array de textos predefinidos
  texts: string[] = [
    "The Last Train Home: Write about a mysterious train that appears only at midnight and the passengers who board it.",
    "A Day in the Life of an Inanimate Object: Choose an everyday object and narrate its experiences from its perspective.",
    "Parallel Universe: Explore a world where one major historical event had a different outcome.",
    "The Forgotten Library: A character discovers a hidden library that contains books that can change reality.",
    "Letters to the Future: Write a series of letters from a character to their future self.",
    "A Lesson Learned the Hard Way: Share a personal story where you learned an important lesson.",
    "The Influence of a Mentor: Write about someone who significantly impacted your life and the lessons they taught you.",
    "My Favorite Place: Describe a location that holds special meaning to you and why.",
    "The Impact of Technology on Relationships: Reflect on how technology has changed the way we connect with others.",
    "A Moment of Courage: Describe a time when you had to be brave, and what you learned from it.",
    "The Importance of Arts Education: Argue for or against the inclusion of arts in school curriculums.",
    "Social Media: A Blessing or a Curse?: Discuss the effects of social media on society today.",
    "Climate Change Action: Propose solutions individuals can take to combat climate change.",
    "The Future of Work: What will the workplace look like in 10 years? Discuss trends and changes.",
    "Universal Basic Income: Explore the pros and cons of implementing UBI in modern economies.",
    "A World Without Gravity: Imagine a society where gravity doesn’t exist and how people adapt.",
    "The Last Dragon: Write a story about the last dragon in a world where they were once common.",
    "Time Travel Tourism: Describe a travel agency that offers trips to different time periods.",
    "Artificial Intelligence and Emotions: Explore the ethical implications of AI developing feelings.",
    "The Forgotten Gods: Write about ancient gods trying to reclaim their worshippers in the modern world."
  ];

  countWords(text: string): number {
    return text.trim().split(/\s+/).filter((word) => word.length > 0).length;
  }

  onInputChange(event: Event): void {
    const target = event.target as HTMLTextAreaElement;
    this.writingText = target.value;
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
    event.preventDefault();
    console.log('Writing submitted:', this.writingText);
    // Aquí puedes implementar la lógica para enviar el writing, por ejemplo, a un servidor
  }

  generateNewText(): void {
    const randomIndex = Math.floor(Math.random() * this.texts.length);
    this.outputText = this.texts[randomIndex]; // Asigna un texto aleatorio a outputText
  }
}
