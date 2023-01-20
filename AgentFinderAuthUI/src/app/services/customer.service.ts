import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observer, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private baseUrl: string = 'https://localhost:7216/api/customer/';
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(`${this.baseUrl}list`);
  }

  Remove(id: number): any {
    return this.http.delete<any>(`${this.baseUrl}delete`);
  }

  private _refreshrequired=new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }
}
