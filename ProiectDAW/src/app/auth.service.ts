import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authUrl = "https://localhost:5001/api/Authentication"
  httpOptions = {
    headers : new HttpHeaders({ 'Content-Type' : 'application/json'})
  };

  constructor(private http : HttpClient, private router : Router, private jwtService : JwtHelperService) { }

  register(userData : any) : Observable<any> {
    return this.http.post<any>(`${this.authUrl}/signUp`, userData)
    .pipe(map(() => {
      this.router.navigate(['/login']);
    }));
  }

  login(userData : any) : Observable<any> {
    return this.http.post<any>(`${this.authUrl}/login`, userData)
    .pipe(map((response : any) => {
      console.log(response);
      if(response?.accessToken) {
        localStorage.setItem('token', response.accessToken);
        this.router.navigate(['/dashboard']);
      }
    }));
  }

  isLoggedIn() {
    const token = localStorage.getItem('token') || "";
    return !this.jwtService.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
