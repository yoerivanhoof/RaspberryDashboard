import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {DiscordServer} from '../model/discord-server';

@Injectable({
  providedIn: 'root'
})
export class DiscordService {

  constructor(public httpClient: HttpClient) {
  }

  public getCurrent(): Observable<DiscordServer> {
    return this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`);
  }
}
