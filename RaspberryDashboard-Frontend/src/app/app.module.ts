import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DiscordComponent } from './component/discord/discord.component';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { LightsComponent } from './component/lights/lights.component';
import { NavigationComponent } from './component/navigation/navigation.component';
import { DiscordServerComponent } from './component/part/discord-server/discord-server.component';
import { DiscordVoiceChannelComponent } from './component/part/discord-voice-channel/discord-voice-channel.component';
import { DiscordUserComponent } from './component/part/discord-user/discord-user.component';
import { LightComponent } from './component/part/light/light.component';
import {MatCardModule} from "@angular/material/card";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatListModule} from "@angular/material/list";
import {DragDropModule} from "@angular/cdk/drag-drop";
import {HttpClientModule} from "@angular/common/http";
import {MatMenuModule} from "@angular/material/menu";
import {FormsModule} from "@angular/forms";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatButtonModule} from "@angular/material/button";
import {LayoutModule} from "@angular/cdk/layout";
import {MatFormFieldModule} from "@angular/material/form-field";

@NgModule({
  declarations: [
    AppComponent,
    DiscordComponent,
    DashboardComponent,
    LightsComponent,
    NavigationComponent,
    DiscordServerComponent,
    DiscordVoiceChannelComponent,
    DiscordUserComponent,
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
    MatMenuModule,
    MatFormFieldModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
