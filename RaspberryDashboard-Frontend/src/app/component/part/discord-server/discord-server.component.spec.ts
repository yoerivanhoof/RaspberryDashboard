import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscordServerComponent } from './discord-server.component';

describe('DiscordServerComponent', () => {
  let component: DiscordServerComponent;
  let fixture: ComponentFixture<DiscordServerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DiscordServerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscordServerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
