import {Component, Input, OnInit} from '@angular/core';
import {DiscordUser} from "../../../model/discord-user";

@Component({
  selector: 'app-discord-user',
  templateUrl: './discord-user.component.html',
  styleUrls: ['./discord-user.component.scss']
})
export class DiscordUserComponent implements OnInit {
  @Input() discordUser: DiscordUser;
  constructor() { }

  ngOnInit() {
  }
}
