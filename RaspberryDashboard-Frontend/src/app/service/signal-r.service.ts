import {Injectable} from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {log} from 'util';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  constructor() {
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/dashboardhub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('MessageReceived', (data: any) => {
      log(data);
    });
  };

  public SendMessage(message: string) {
    this.hubConnection.invoke('NewMessage', message);
  }
}
