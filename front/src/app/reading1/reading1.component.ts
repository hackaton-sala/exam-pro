import { Component, OnInit } from '@angular/core';
import { GrammarService } from '../services/application/gramar.service';

interface Option {
  id: string;
  title: string;
  texts: { label: string; value: string }[];
  selected: string | null; // El valor seleccionado
}

@Component({
  selector: 'app-reading1',
  templateUrl: './reading1.component.html',
  styleUrls: ['./reading1.component.css']
})
export class Reading1Component implements OnInit {

  constructor(public grammarService: GrammarService) {

  }
  options: Option[] = [
    { id: 'A', title: 'Opción A', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null },
    { id: 'B', title: 'Opción B', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null },
    { id: 'C', title: 'Opción C', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null },
    { id: 'D', title: 'Opción D', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null },
    { id: 'E', title: 'Opción E', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null },
    { id: 'F', title: 'Opción F', texts: [{ label: 'Texto 1', value: 'A' }, { label: 'Texto 2', value: 'B' }, { label: 'Texto 3', value: 'C' }, { label: 'Texto 4', value: 'D' }], selected: null }
  ];

  copyText() {
    // Lógica para copiar el texto
    const inputText = document.getElementById('inputText') as HTMLTextAreaElement;
    inputText.select();
    document.execCommand('copy');
  }

  generateText() {
    // Lógica para generar nuevo texto
    const inputText = document.getElementById('inputText') as HTMLTextAreaElement;
    inputText.value = 'Nuevo texto generado'; // Aquí puedes agregar la lógica para generar el texto
  }

  isAllSelected(): boolean {
    return this.options.every(option => option.selected !== null);
  }

  checkSelection() {
    // Este método se llama cada vez que se selecciona una opción
  }

  submitAnswers() {
    // Lógica para manejar la respuesta del formulario
    console.log('Respuestas enviadas:', this.options);
  }
  ngOnInit(): void {
    this.generateQuestions();
  }

  generateQuestions() {
    const prompt = "Generate 5 grammar questions for a B2 level English exam with 4 options each.";
    this.grammarService.generateQuestions(prompt).subscribe(
      (response) => {
        console.log(response);  // Mostrar las preguntas generadas
      },
      (error) => {
        console.error('Error al generar preguntas', error);
      }
    );
  }
  checkSelection() {
    // Este método se llama cada vez que se selecciona una opción
  }

  submitAnswers() {
    // Lógica para manejar la respuesta del formulario
    console.log('Respuestas enviadas:', this.options);
  }
}
