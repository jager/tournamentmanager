import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  public url: string = environment.apiUrl

  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  constructor(private http: HttpClient) {

  }

  post<T>(url: string, body: any) {
    return this.http.post<T>(url, body, this.httpOptions)
  }
}
