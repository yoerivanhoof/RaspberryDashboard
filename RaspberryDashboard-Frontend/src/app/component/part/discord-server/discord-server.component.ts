import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DiscordServer} from "../../../model/discord/discord-server";
import {DiscordUser} from "../../../model/discord/discord-user";

@Component({
  selector: 'app-discord-server',
  templateUrl: './discord-server.component.html',
  styleUrls: ['./discord-server.component.scss']
})
export class DiscordServerComponent implements OnInit {
  @Input() discordServer: DiscordServer;
  @Output() userEditedEvent = new EventEmitter<DiscordUser>();


  constructor() {
  }

  ngOnInit() {
  }

}
