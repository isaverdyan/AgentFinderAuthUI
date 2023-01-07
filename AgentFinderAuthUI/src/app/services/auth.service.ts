import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import {JwtHelperService} from '@auth0/angular-jwt';
import {TokenApiModel} from '../models/token-api.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = "https://localhost:7216/api/user/";
  private userPayload: any;

  constructor(private http: HttpClient, private router: Router) {  
    this.userPayload = this.decodedToken();
   }

  signOut() {
    localStorage.clear();
    this.router.navigate(['login'])
    //localStorage.removeItem('token');
  }

  signUp(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj);
  }

  signIn(loginObj: any) {
    return this.http.post<any>(`${this.baseUrl}authenticate`, loginObj);
  }

  storeToken(tokenValue: string){
    localStorage.setItem('token', tokenValue)
  }

  storeRefreshToken(tokenValue: string){
    localStorage.setItem('refreshtoken', tokenValue)
  }

  getToken(){
    return localStorage.getItem('token')
  }

  getRefreshToken() {
    return localStorage.getItem('refreshtoken')
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('token')
  }

  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token));
    return jwtHelper.decodeToken(token);
  }

  getFullNameFromToken() {
    if(this.userPayload)
      return this.userPayload.name; 
  }

  getRoleFromToken() {
    if(this.userPayload)
      return this.userPayload.role;
  }

  renewToken(tokenApi: TokenApiModel) {
    return this.http.post<any>(`${this.baseUrl}refresh`, tokenApi);
  }
}
