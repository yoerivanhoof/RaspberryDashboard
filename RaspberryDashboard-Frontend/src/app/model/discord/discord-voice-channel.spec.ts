import { DiscordVoiceChannel } from './discord-voice-channel';

describe('DiscordVoiceChannel', () => {
  it('should create an instance', () => {
    expect(new DiscordVoiceChannel()).toBeTruthy();
  });
});
