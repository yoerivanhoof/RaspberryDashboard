import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscordVoiceChannelComponent } from './discord-voice-channel.component';

describe('DiscordVoiceChannelComponent', () => {
  let component: DiscordVoiceChannelComponent;
  let fixture: ComponentFixture<DiscordVoiceChannelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DiscordVoiceChannelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscordVoiceChannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
