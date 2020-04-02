import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {log} from "util";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TestingService {

  constructor(public httpClient: HttpClient) { }

  public testingSomething(): Observable<string>{
    return this.httpClient.get(`${environment.backendURL}/testing`, { responseType: 'text'})
  }

}
