import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';
import { AuthService } from '../services/common/auth.service';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styles: []
})
export class ApplicationComponent implements OnInit {
  
  constructor( 
    private router: Router,
    private authService: AuthService
  ) {
    // this.router.events.pipe(filter((event) => event instanceof NavigationEnd))
    //   .subscribe((event) => {
    //     this.authService
    //       .refrescar()
    //         .subscribe((data: any) => {
    //           if(!data){
    //             this.router.navigateByUrl('/login', {state: {redirect: this.router.url}})
    //           }
    //         })
    //   })
  }
  
  ngOnInit(): void { }
}
