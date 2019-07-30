import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';


const authenticationRoutes: Routes = [
    {
        path: 'auth',
        children: [
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent }
        ]
    }
];

export const routing = RouterModule.forChild(authenticationRoutes);
