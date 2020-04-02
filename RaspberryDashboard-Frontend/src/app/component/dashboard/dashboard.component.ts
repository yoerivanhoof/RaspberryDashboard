import {Component} from '@angular/core';
import {TestingService} from "../../service/testing.service";
import {SignalRService} from '../../service/signal-r.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  public text = 'Click meeeeeeeeeeeeeeeee';

  constructor(public testingService: TestingService, public signalRService: SignalRService) {
    this.signalRService.startConnection();
  }

  test() {
    this.signalRService.SendMessage('HI');
  }
}
