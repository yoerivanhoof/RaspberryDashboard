import {Component} from '@angular/core';
import {TestingService} from "../../service/testing.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  public text = 'Click meeeeeeeeeeeeeeeee';

  constructor(public testingService: TestingService) {
  }

  test() {
    this.testingService.testingSomething().subscribe((response: string) => {
      this.text = response;
    });
  }
}
