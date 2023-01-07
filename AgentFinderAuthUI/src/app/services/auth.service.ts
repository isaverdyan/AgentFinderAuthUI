import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = "https://localhost:7216/api/User/";
  constructor(private http: HttpClient, private router: Router) { 

  }

  signOut() {
    localStorage.clear();
    this.router.navigate(['login'])
    //localStorage.removeItem('token');
  }

  signUp(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj);
  }

  login(loginObj: any) {
    return this.http.post<any>(`${this.baseUrl}authenticate`, loginObj);
  }

  storeToken(tokenValue: string){
    localStorage.setItem('token', tokenValue)
  }

  getToken(){
    return localStorage.getItem('token')
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('token')
  }
}
