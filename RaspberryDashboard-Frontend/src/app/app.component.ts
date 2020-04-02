import { Component } from '@angular/core';
import {log} from "util";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RaspberryDashboard-Frontend';

  constructor(private http: HttpClient){
    this.http.get("http://localhost:5000/weatherforecast").subscribe(result=>{
      this.title = result.toString();
    })
  }
}
