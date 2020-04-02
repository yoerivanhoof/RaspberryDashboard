import {Component, Input, OnInit} from '@angular/core';
import {DiscordVoiceChannel} from '../../../model/discord-voice-channel';

@Component({
  selector: 'app-discord-voice-channel',
  templateUrl: './discord-voice-channel.component.html',
  styleUrls: ['./discord-voice-channel.component.scss']
})
export class DiscordVoiceChannelComponent implements OnInit {

  @Input() voiceChannel: DiscordVoiceChannel;
  constructor() { }

  ngOnInit() {
  }

}
