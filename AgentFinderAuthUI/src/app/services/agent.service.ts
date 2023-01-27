import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observer, Subject } from 'rxjs';
import { SubsribeApiModel } from '../models/subscribe.model';

@Injectable({
  providedIn: 'root'
})
export class AgentService {
  private baseUrl: string = 'https://localhost:7216/api/agent/';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(`${this.baseUrl}list`);
  }

  Remove(id: number): any {
    return this.http.delete<any>(`${this.baseUrl}delete`);
  }

  subscribeToAgent(subscribeApiModel: SubsribeApiModel) {
    var token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('content-type', 'application/json') 
                                      .set('Access-Control-Allow-Origin','*')
                                      .set('Authorization', `Bearer ${token}`);
   
    let options = { headers: headers };
    
    var body = {
      subscribeModel: subscribeApiModel
    }
    const req = new HttpRequest('POST', `${this.baseUrl}subscribe`, subscribeApiModel, options)
    
    this.http.request(req).subscribe( res => { console.log(' uuuuuuuuu ' + res); })
  }

  private _refreshrequired=new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }

}
