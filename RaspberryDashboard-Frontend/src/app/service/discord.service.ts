import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {environment} from '../../environments/environment';
import {DiscordServer} from '../model/discord-server';
import * as signalR from '@aspnet/signalr';
import {DiscordUser} from '../model/discord-user';

@Injectable({
  providedIn: 'root'
})
export class DiscordService {
  public DiscordServer;
  private hubConnection: signalR.HubConnection;
  private subject: BehaviorSubject<DiscordServer> = new BehaviorSubject<DiscordServer>(new DiscordServer());
  public discordServer = this.subject.asObservable();

  constructor(public httpClient: HttpClient) {
    this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`).subscribe(response => {
      console.log(response);
      this.subject.next(response);
    });
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/discordhub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('VoiceStateUpdated', (data: any) => {
      this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`).subscribe(response => {
        this.subject.next(response);
      });
    });
  }

  public getCurrent(): DiscordServer {
    return this.subject.getValue();
  }

  updateUser($event: DiscordUser) {
    console.log($event);
    this.httpClient.post(`${environment.backendURL}/discord`, $event).subscribe(response => {
      console.log(response);

    });
  }
}
