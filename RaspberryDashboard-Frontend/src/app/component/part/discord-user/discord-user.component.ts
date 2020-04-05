import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DiscordUser} from "../../../model/discord-user";
import {MatSlideToggleChange} from "@angular/material/slide-toggle";

@Component({
  selector: 'app-discord-user',
  templateUrl: './discord-user.component.html',
  styleUrls: ['./discord-user.component.scss']
})
export class DiscordUserComponent implements OnInit {
  @Input() discordUser: DiscordUser;
  @Output() userEditedEvent = new EventEmitter<DiscordUser>();
  constructor() { }

  ngOnInit() {
  }

  muteUser($event: MatSlideToggleChange ) {
    this.discordUser.Muted = $event.checked;
  }
}
