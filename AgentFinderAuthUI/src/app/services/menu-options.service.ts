import { Injectable } from '@angular/core';
import { Router } from 'express-serve-static-core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config';
 
import { ApiAbstractService } from './api-abstract.service';
import { IMenuOptionsService } from '../shared/interfaces/iMenuOptionsService';
import { Observable } from 'rxjs';
import { IMenuOptionsAPIDTO } from '../shared/dto/menu-options-dto';


@Injectable({
  providedIn: 'root'
})
export class MenuOptionsService {
  private baseUrl: string = 'https://localhost:7216/api/MenuOptions/list';
  constructor(
    private readonly http: HttpClient
    ) { 
   // super();
    //console.log(' uuuuuuuuuuuuuu '+ this.appConfig.agentFinderApi);
    //this.endpoint = `${this.appConfig.agentFinderApi}api/menuoptions/`;
   
  }
  
  getAll() {
    return this.http.get<any>(this.baseUrl);
  }

 
}
