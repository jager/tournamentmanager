import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tap, catchError, map } from 'rxjs/operators';
import { User } from '../login/User';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BaseService } from '../services/base.service';
import { AuthResponse } from '../services/responses/authResponse';
import { of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseService {
  constructor(private router: Router, http: HttpClient) {
    super(http)
  }
  isLoggedIn() : boolean {

    let token = localStorage.getItem('token');
    if (!token)
      return false

    let isExpired = this.isExpired();
    if (isExpired) {
      localStorage.removeItem('token')
    }

    return !isExpired;

    //return localStorage.getItem('token') == 'sometoken'
  }

  private isExpired(): boolean {
    const timeout = 3600
    return false
  }

  // store the URL so we can redirect after logging in
  redirectUrl: string | null = null;

  login(user: User) {
    console.log("AuthService:")
    console.log(JSON.stringify(user))
    return this.post<AuthResponse>(this.url + "/api/Auth/signin", JSON.stringify(user))
      .pipe(
          map(authResponse => this.setSession(authResponse)),
          catchError(this.handleError)
          )

  }

  private setSession(authResponse: AuthResponse) {
    console.log("Response:")
    console.log(authResponse);

    if (authResponse && authResponse.token) {
      localStorage.setItem('token', authResponse.token)
      return true;
    }
    return false
  }

  private handleError(error: any) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(`${error.error.title} ${error.status} - traceId: ${error.error.traceId}`);
    }
    return of(1);
  }


  logout(): void {

    localStorage.removeItem('token')
    this.router.navigate(['/login']);
  }
}
