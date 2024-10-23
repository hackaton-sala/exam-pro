import { Component, OnInit } from '@angular/core';
import { GrammarService } from '../services/application/gramar.service';

interface Option {
  id: string;
  title: string;
  texts: { label: string; value: string }[];
  selected: string | null; // El valor seleccionado
  correctAnswer: string; // La respuesta correcta
}

@Component({
  selector: 'app-reading1',
  templateUrl: './reading1.component.html',
  styleUrls: ['./reading1.component.css']
})
export class Reading1Component implements OnInit {

  submitted: boolean = false;

  texts: string[] = [
    "Many people believe that the internet has changed the way we communicate. Before the internet became widespread, people used to send letters or make phone calls to keep in touch with friends and family. Now, however, it is much easier to stay connected thanks to various online platforms. One of the main advantages of the internet is that it allows people to communicate almost (1)________.\n" +
    "\n" +
    "Additionally, the internet provides access to vast amounts of information. In the past, if someone wanted to research a topic, they would need to go to a library and look through books. Nowadays, anyone can find information (2)________ by using a search engine. This has made learning more accessible to people all over the world.\n" +
    "\n" +
    "However, while the internet has many benefits, it also has its drawbacks. One common concern is that spending too much time online can negatively (3)________ people's social skills. Some people may prefer to interact online rather than in person, which can lead to feelings of isolation.\n" +
    "\n" +
    "Another issue is that not all information on the internet is accurate. It is important to (4)________ the sources of information carefully to avoid spreading misinformation. In some cases, false information can lead to serious consequences, especially when it involves health or safety advice.\n" +
    "\n" +
    "Despite these challenges, most people agree that the internet is an essential tool in modern life. It has changed the way we work, learn, and (5)________ with each other. The internet has opened up new opportunities for education, business, and entertainment, making it a key part of daily life.\n" +
    "\n" +
    "In the future, it is likely that the internet will continue to (6)________, bringing both new opportunities and new challenges."
  ];

  options: Option[] = [];

  constructor(public grammarService: GrammarService) {}

  ngOnInit(): void {
    // No generamos las preguntas aquí
  }

  copyText() {
    const inputText = document.getElementById('inputText') as HTMLTextAreaElement;
    inputText.select();
    document.execCommand('copy');
  }

  isAllSelected(): boolean {
    return this.options.every(option => option.selected !== null);
  }

  submitAnswers() {
    const results = this.options.map(option => ({
      title: option.title,
      selected: option.selected,
      correct: option.selected === option.correctAnswer // Verifica si la respuesta es correcta
    }));

    console.log('Respuestas enviadas:', results);

    // Establece la variable submitted a true
    this.submitted = true;

    // Mostrar resultados en consola (puedes cambiar esto para mostrar en la UI)
    results.forEach(result => {
      console.log(`${result.title}: ${result.selected} - ${result.correct ? 'Correcto' : 'Incorrecto'}`);
    });
  }

  generateNewText(): void {
    const randomIndex = Math.floor(Math.random() * this.texts.length);
    const inputText = document.getElementById('inputText') as HTMLTextAreaElement;
    inputText.value = this.texts[randomIndex];

    // Generar preguntas aquí al pulsar el botón
    const predefinedOptions: Option[] = [
      {
        id: '1',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) permanently', value: 'A' },
          { label: 'B) instantly', value: 'B' },
          { label: 'C) randomly', value: 'C' },
          { label: 'D) slowly', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'B' // Respuesta correcta
      },
      {
        id: '2',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) immediately', value: 'A' },
          { label: 'B) gradually', value: 'B' },
          { label: 'C) rarely', value: 'C' },
          { label: 'D) temporarily', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'A' // Respuesta correcta
      },
      {
        id: '3',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) impact', value: 'A' },
          { label: 'B) replace', value: 'B' },
          { label: 'C) solve', value: 'C' },
          { label: 'D) help', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'A' // Respuesta correcta
      },
      {
        id: '4',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) discover', value: 'A' },
          { label: 'B) use', value: 'B' },
          { label: 'C) check', value: 'C' },
          { label: 'D) guess', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'C' // Respuesta correcta
      },
      {
        id: '5',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) communicate', value: 'A' },
          { label: 'B) compete', value: 'B' },
          { label: 'C) challenge', value: 'C' },
          { label: 'D) complain', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'A' // Respuesta correcta
      },
      {
        id: '6',
        title: 'Choose the best word to complete the sentence:',
        texts: [
          { label: 'A) decrease', value: 'A' },
          { label: 'B) disappear', value: 'B' },
          { label: 'C) evolve', value: 'C' },
          { label: 'D) repeat', value: 'D' }
        ],
        selected: null,
        correctAnswer: 'C' // Respuesta correcta
      }
    ];

    this.options = predefinedOptions;
  }
}
