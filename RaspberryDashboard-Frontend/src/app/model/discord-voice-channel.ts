import {DiscordUser} from './discord-user';

export class DiscordVoiceChannel {
  public users: DiscordUser[] = [];
  public id: number;
  public name: string;
}
