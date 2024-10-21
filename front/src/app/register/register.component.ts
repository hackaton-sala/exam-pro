import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  countries = [
    { name: 'Alemania', value: 'alemania' },
    { name: 'Andorra', value: 'andorra' },
    { name: 'Argelia', value: 'argelia' },
    { name: 'Argentina', value: 'argentina' },
    { name: 'Australia', value: 'australia' },
    { name: 'Austria', value: 'austria' },
    { name: 'Bahréin', value: 'bahréin' },
    { name: 'Bélgica', value: 'bélgica' },
    { name: 'Bielorrusia', value: 'bielorrusia' },
    { name: 'Bolivia', value: 'bolivia' },
    { name: 'Brasil', value: 'brasil' },
    { name: 'Bulgaria', value: 'bulgaria' },
    { name: 'Canadá', value: 'canadá' },
    { name: 'Catar', value: 'catar' },
    { name: 'Chile', value: 'chile' },
    { name: 'China', value: 'china' },
    { name: 'Chipre', value: 'chipre' },
    { name: 'Colombia', value: 'colombia' },
    { name: 'Corea del Sur', value: 'corea-del-sur' },
    { name: 'Costa Rica', value: 'costa-rica' },
    { name: 'Croacia', value: 'croacia' },
    { name: 'Dinamarca', value: 'dinamarca' },
    { name: 'Egipto', value: 'egipto' },
    { name: 'Emiratos Árabes Unidos', value: 'emiratos-arabes-unidos' },
    { name: 'Eslovaquia', value: 'eslovaquia' },
    { name: 'Eslovenia', value: 'eslovenia' },
    { name: 'España', value: 'españa' },
    { name: 'Estados Unidos', value: 'estados-unidos' },
    { name: 'Estonia', value: 'estonia' },
    { name: 'Filipinas', value: 'filipinas' },
    { name: 'Finlandia', value: 'finlandia' },
    { name: 'Francia', value: 'francia' },
    { name: 'Fiji', value: 'fiji' },
    { name: 'Ghana', value: 'ghana' },
    { name: 'Grecia', value: 'grecia' },
    { name: 'Hong Kong', value: 'hong-kong' },
    { name: 'Hungría', value: 'hungría' },
    { name: 'India', value: 'india' },
    { name: 'Indonesia', value: 'indonesia' },
    { name: 'Irlanda', value: 'irlanda' },
    { name: 'Islandia', value: 'islandia' },
    { name: 'Israel', value: 'israel' },
    { name: 'Italia', value: 'italia' },
    { name: 'Japón', value: 'japón' },
    { name: 'Jordania', value: 'jordania' },
    { name: 'Kazajistán', value: 'kazajistán' },
    { name: 'Kenia', value: 'kenia' },
    { name: 'Kuwait', value: 'kuwait' },
    { name: 'Letonia', value: 'letonia' },
    { name: 'Líbano', value: 'líbano' },
    { name: 'Libia', value: 'libia' },
    { name: 'Lituania', value: 'lituania' },
    { name: 'Luxemburgo', value: 'luxemburgo' },
    { name: 'Macedonia', value: 'macedonia' },
    { name: 'Malasia', value: 'malasia' },
    { name: 'Malta', value: 'malta' },
    { name: 'Mauricio', value: 'mauricio' },
    { name: 'México', value: 'méxico' },
    { name: 'Mónaco', value: 'mónaco' },
    { name: 'Marruecos', value: 'marruecos' },
    { name: 'Nepal', value: 'nepal' },
    { name: 'Nigeria', value: 'nigeria' },
    { name: 'Noruega', value: 'noruega' },
    { name: 'Nueva Zelanda', value: 'nueva-zelanda' },
    { name: 'Omán', value: 'omán' },
    { name: 'Pakistán', value: 'pakistan' },
    { name: 'Panamá', value: 'panama' },
    { name: 'Paraguay', value: 'paraguay' },
    { name: 'Perú', value: 'perú' },
    { name: 'Polonia', value: 'polonia' },
    { name: 'Portugal', value: 'portugal' },
    { name: 'Qatar', value: 'qatar' },
    { name: 'Reino Unido', value: 'reino-unido' },
    { name: 'República Checa', value: 'rep-checa' },
    { name: 'Rumanía', value: 'rumania' },
    { name: 'Rusia', value: 'rusia' },
    { name: 'Serbia', value: 'serbia' },
    { name: 'Singapur', value: 'singapur' },
    { name: 'Sudáfrica', value: 'sudafrica' },
    { name: 'Suecia', value: 'suecia' },
    { name: 'Suiza', value: 'suiza' },
    { name: 'Taiwán', value: 'taiwán' },
    { name: 'Tailandia', value: 'tailandia' },
    { name: 'Turquía', value: 'turquía' },
    { name: 'Túnez', value: 'túnez' },
    { name: 'Ucrania', value: 'ucrania' },
    { name: 'Uruguay', value: 'uruguay' },
    { name: 'Uzbekistán', value: 'uzbekistan' },
    { name: 'Venezuela', value: 'venezuela' },
    { name: 'Vietnam', value: 'vietnam' },
    { name: 'Zimbabue', value: 'zimbabue' }
  ];
  public registrationForm: FormGroup;
  errorMessage: string = '';

  constructor(private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    });

    this.registrationForm.valueChanges.subscribe(() => {
      this.checkPasswords();
    });
  }

  checkPasswords() {
    const password = this.registrationForm.get('password')?.value;
    const confirmPassword = this.registrationForm.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      this.registrationForm.get('confirmPassword')?.setErrors({ mismatch: true });
    } else {
      this.registrationForm.get('confirmPassword')?.setErrors(null);
    }
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      console.log("Formulario enviado con éxito", this.registrationForm.value);
    } else {
      console.log("El formulario contiene errores");
    }
  }
}
