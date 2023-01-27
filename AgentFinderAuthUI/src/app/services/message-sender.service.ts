import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Customer } from '../components/customers/customers.component';
import { MessageApiModel } from '../models/message.model';
import { Observable } from 'rxjs';
import { AnyARecord } from 'dns';

@Injectable({
  providedIn: 'root'
})
export class MessageSenderService {
  private baseUrl: string = 'https://localhost:7216/api/notification/';


  constructor(private http: HttpClient) { }

  sendMessageToCustomer(messageModel: MessageApiModel) 
  {   
    var token = localStorage.getItem('token');
    console.log(' token = ' + token);
 
    const headers = new HttpHeaders().set('content-type', 'application/json') 
                                      .set('Access-Control-Allow-Origin','*')
                                      .set('Authorization', `Bearer ${token}`);
   
    let options = { headers: headers };
    var body = {
      messageModel: messageModel
    }
    const req = new HttpRequest('POST', `${this.baseUrl}offers`, body, options)
    
    this.http.request(req).subscribe( res => { console.log(' uuuuuuuuu ' + res); })
  }
}
