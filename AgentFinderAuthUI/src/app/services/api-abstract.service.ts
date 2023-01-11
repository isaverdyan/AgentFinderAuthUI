import { Injectable } from '@angular/core';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError  } from 'rxjs';


@Injectable()
export class ApiAbstractService {
  protected endpoint: string;

  protected headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  //in future we will create global error handler
  protected handleError(error: HttpErrorResponse): Observable<any> {
    console.log("handleError", error);
    let errorMessage = (error.error && error.error.message) ? error.error.message : error.error;
    if (errorMessage === null) errorMessage = "";
    return throwError (errorMessage);
  }
}
