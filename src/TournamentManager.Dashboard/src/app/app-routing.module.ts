import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './auth/auth.guard';
import { CreateComponent } from './dashboard/tournaments/create/create.component';
import { ListComponent } from './dashboard/tournaments/list/list.component';
import { ViewComponent } from './dashboard/tournaments/view/view.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ReminderComponent } from './reminder/reminder.component';

const routes: Routes = [
  { path: 'password-restore', component: ReminderComponent },
  { path: 'tournaments',  component: ListComponent, canActivate: [ authGuard ] },
  { path: 'tournaments/create', component: CreateComponent, canActivate: [ authGuard ] },
  { path: 'tournaments/view/:id', component: ViewComponent, canActivate: [ authGuard ] },
  { path: 'login', component: LoginComponent },
  { path: '', component: LoginComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
