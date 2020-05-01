import {DiscordUser} from './discord-user';

export class DiscordVoiceChannel {
  public Users: DiscordUser[] = [];
  public Id: string;
  public Name: string;
}
