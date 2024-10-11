import { Routes } from '@angular/router';
import { ApplicationComponent } from './application.component';
import { UsersComponent } from './users/users.component';

export const routes: Routes = [
    {
        path: '',
        component: ApplicationComponent,
        children: [
            // {
            //     path: '',
            //     // component: DashboardComponent,
            // },
            {
                path: 'users',
                component: UsersComponent
            },

            { path: '', redirectTo: '', pathMatch: 'full'}
        ]
    }
];