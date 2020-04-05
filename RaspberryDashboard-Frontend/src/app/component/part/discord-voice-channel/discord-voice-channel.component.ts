import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from "@angular/cdk/drag-drop";
import {DiscordUser} from "../../../model/discord-user";
import {DiscordVoiceChannel} from "../../../model/discord-voice-channel";

@Component({
  selector: 'app-discord-voice-channel',
  templateUrl: './discord-voice-channel.component.html',
  styleUrls: ['./discord-voice-channel.component.scss']
})
export class DiscordVoiceChannelComponent implements OnInit {

  @Input() voiceChannel: DiscordVoiceChannel;
  @Input() allChannels: DiscordVoiceChannel[];
  @Output() userEditedEvent = new EventEmitter<DiscordUser>();

  constructor() {
  }

  ngOnInit() {
  }

  drop(event: CdkDragDrop<DiscordUser[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      event.container.data[event.currentIndex].ChannelId = event.container.id;
      this.userEditedEvent.emit(event.container.data[event.currentIndex]);
    }
  }

  getOtherChannels() {
    const channels = [];
    this.allChannels.forEach(channel => {
      if (channel.Id !== this.voiceChannel.Id) {
        channels.push(channel.Id);
      }
    });
    return channels;
  }

}
