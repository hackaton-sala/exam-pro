import { Component, OnInit } from '@angular/core';
import { GrammarService } from '../services/application/gramar.service';

@Component({
  selector: 'app-reading1',
  templateUrl: './reading1.component.html',
  styleUrl: './reading1.component.css'
})
export class Reading1Component implements OnInit {
  
  constructor(public grammarService: GrammarService) {

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
}
