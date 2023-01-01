import { Component, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})


export class NavComponent {
  constructor(
    @Inject(DOCUMENT) public document: Document,
    private AuthService: AuthService
  ) {}

  logout() {
    this.AuthService.logout();
  }
}
