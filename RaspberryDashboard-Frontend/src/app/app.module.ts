import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './component/navigation/navigation.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatGridListModule, MatCardModule, MatMenuModule } from '@angular/material';
import { DiscordComponent } from './component/discord/discord.component';
import { DiscordUserComponent } from './component/part/discord-user/discord-user.component';
import { DiscordVoiceChannelComponent } from './component/part/discord-voice-channel/discord-voice-channel.component';
import { DiscordServerComponent } from './component/part/discord-server/discord-server.component';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { LightsComponent } from './component/lights/lights.component';
import { LightComponent } from './component/part/light/light.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    NavigationComponent,
    DiscordComponent,
    DiscordUserComponent,
    DiscordVoiceChannelComponent,
    DiscordServerComponent,
    LightsComponent,
    LightComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    DragDropModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
