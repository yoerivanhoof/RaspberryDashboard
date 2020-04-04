import {Component, OnInit} from '@angular/core';
import {DiscordService} from '../../service/discord.service';
import {DiscordServer} from '../../model/discord-server';
import {DiscordUser} from '../../model/discord-user';

@Component({
  selector: 'app-discord',
  templateUrl: './discord.component.html',
  styleUrls: ['./discord.component.scss']
})
export class DiscordComponent implements OnInit {

  public discordServer: DiscordServer = new DiscordServer();

  constructor(public discordService: DiscordService) {

    this.discordService.discordServer.subscribe(server => {
      this.discordServer = server;
    });
  }

  ngOnInit() {
  }

  userEdited($event: DiscordUser) {
    this.discordService.updateUser($event);
  }
}
