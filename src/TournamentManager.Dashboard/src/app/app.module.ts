import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReminderComponent } from './reminder/reminder.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HeaderComponent } from "./dashboard/layout/header/header.component";
import { FooterComponent } from "./dashboard/layout/footer/footer.component";
import { NavComponent } from './dashboard/layout/nav/nav.component';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        ReminderComponent,
        NotFoundComponent,
        HeaderComponent,
        FooterComponent,
        NavComponent,
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule
    ]
})
export class AppModule { }
