import { Component } from '@angular/core';

@Component({
  selector: 'app-reading5',
  templateUrl: './reading5.component.html',
  styleUrls: ['./reading5.component.css']
})
export class Reading5Component {
  // Usar un tipo de objeto con firma de índice
  selectedOptions: { [key: string]: string } = {
    opcionA: '',
    opcionB: '',
    opcionC: '',
    opcionD: '',
    opcionE: '',
    opcionF: ''
  };

  // Método para habilitar el botón de enviar
  isSubmitDisabled(): boolean {
    return !Object.values(this.selectedOptions).every(option => option !== '');
  }

  // Método para manejar el envío de respuestas
  submitResponses() {
    console.log('Respuestas enviadas:', this.selectedOptions);
    // Aquí puedes agregar la lógica para manejar el envío
  }
}
