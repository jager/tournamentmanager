import { Component } from '@angular/core';
import { User } from './User';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  User: User = new User()
  authenticationError : boolean = false
  constructor(private AuthService: AuthService, private router: Router) {

  }

  onLogin(): void {
    console.log("LoginComponent:")
    console.log(this.User)
    this.AuthService.login(this.User).subscribe(
        result => {
          if (result) {
            this.router.navigate(['/tournaments'])
          } else {
            this.authenticationError = true
          }
        }
      )

  }
}
