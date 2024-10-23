import { Component } from '@angular/core';

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
export class Reading1Component {
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
}
