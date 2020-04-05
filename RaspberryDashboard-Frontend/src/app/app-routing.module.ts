import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LightsComponent} from "./component/lights/lights.component";
import {DiscordComponent} from "./component/discord/discord.component";
import {DashboardComponent} from "./component/dashboard/dashboard.component";


const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent},
  { path: 'discord', component: DiscordComponent},
  { path: 'lights', component: LightsComponent},
  { path: '', redirectTo: '/dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: '/dashboard'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
