import { Injectable } from '@angular/core';
import { Router } from 'express-serve-static-core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config';
 
import { ApiAbstractService } from './api-abstract.service';

@Injectable({
  providedIn: 'root'
})
export class MenuOptionsService extends ApiAbstractService {
 
  constructor(
    private readonly http: HttpClient, 
    private readonly router: Router,
    private readonly appConfig: AppConfig
    ) { 
    super();
    this.endpoint = `${this.appConfig.userManagementApiUrl}public/users/`;
  }

  getAll() {
    return this.http.get<any>(`${this.appConfig.agentFinderApi}list`);
  }
}
