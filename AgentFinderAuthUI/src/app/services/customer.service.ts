import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  getCustomersByAgent(id: string) {
    const header = new HttpHeaders()
    .set('content-type','application-json')
    .set('Access-Control-Allow-Origin','*');

    return this.http.get<any>(`${this.baseUrl}list/${id}`, {'headers': header});
  }

  private _refreshrequired=new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }
}
