import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {DiscordUser} from "../model/discord-user";
import {DiscordServer} from "../model/discord-server";
import {BehaviorSubject} from "rxjs";
import {HttpClient} from "@angular/common/http";
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class DiscordService {
  private hubConnection: signalR.HubConnection;
  private subject: BehaviorSubject<DiscordServer> = new BehaviorSubject<DiscordServer>(new DiscordServer());
  public discordServer = this.subject.asObservable();

  constructor(public httpClient: HttpClient) {
    this.httpClient.get<DiscordServer>(`${environment.backendURL}/discord`).subscribe(response => {
      this.subject.next(response);
    });
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.hubURL}/discord`)
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
    this.httpClient.post(`${environment.backendURL}/discord`, $event).subscribe(response => {
    });
  }
}
