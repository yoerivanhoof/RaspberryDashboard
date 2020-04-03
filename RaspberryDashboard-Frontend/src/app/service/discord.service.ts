import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {environment} from '../../environments/environment';
import {DiscordServer} from '../model/discord-server';
import * as signalR from '@aspnet/signalr';
import {log} from 'util';

@Injectable({
  providedIn: 'root'
})
export class DiscordService {
  public DiscordServer;
  private hubConnection: signalR.HubConnection;
  private subject: BehaviorSubject<DiscordServer> = new BehaviorSubject<DiscordServer>(new DiscordServer());
  public discordServer = this.subject.asObservable();

  constructor(public httpClient: HttpClient) {
    this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`).subscribe(responce => {
      this.subject.next(responce);
    });
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/discordhub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('VoiceStateUpdated', (data: any) => {
      this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`).subscribe(responce => {
        this.subject.next(responce);
      });
    });
  }

  public getCurrent(): DiscordServer {
    return this.subject.getValue();
  }
}
