import {Component} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {OverlayContainer} from '@angular/cdk/overlay';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RaspberryDashboard-Frontend';

  constructor(private http: HttpClient, overlayContainer: OverlayContainer) {
    overlayContainer.getContainerElement().classList.add('candy-app-theme');
  }
}
