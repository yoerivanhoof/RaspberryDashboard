import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DiscordVoiceChannel} from '../../../model/discord-voice-channel';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import {DiscordUser} from '../../../model/discord-user';

@Component({
  selector: 'app-discord-voice-channel',
  templateUrl: './discord-voice-channel.component.html',
  styleUrls: ['./discord-voice-channel.component.scss']
})
export class DiscordVoiceChannelComponent implements OnInit {

  @Input() voiceChannel: DiscordVoiceChannel;
  @Input() allChannels: DiscordVoiceChannel[];
  @Output() userEditedEvent = new EventEmitter<DiscordUser>();
  otherChannels: string[] = [];

  constructor() {
  }

  ngOnInit() {
    this.allChannels.forEach(channel => {
        this.otherChannels.push(channel.Id);
    });
  }

  dropItem(event: CdkDragDrop<DiscordUser[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
    event.container.data[event.currentIndex].ChannelId = event.container.id;
    this.userEditedEvent.emit(event.container.data[event.currentIndex]);
  }

  getConnectedList(): any[] {
    return this.allChannels.map(x => `${x.Id}`);
  }
}
