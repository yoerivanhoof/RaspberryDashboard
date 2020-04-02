import {Component, Input, OnInit} from '@angular/core';
import {DiscordServer} from '../../../model/discord-server';

@Component({
  selector: 'app-discord-server',
  templateUrl: './discord-server.component.html',
  styleUrls: ['./discord-server.component.scss']
})
export class DiscordServerComponent implements OnInit {
  @Input() discordServer: DiscordServer;
  constructor() { }

  ngOnInit() {
  }

}
