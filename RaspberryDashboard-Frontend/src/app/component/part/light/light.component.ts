import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-light',
  templateUrl: './light.component.html',
  styleUrls: ['./light.component.scss']
})
export class LightComponent implements OnInit {
  pressed = false;
  colorPickerOpen = false;

  constructor() {
  }

  ngOnInit() {
  }

  lightPress() {
    this.pressed = true;
    this.colorPickerOpen = true;
    console.log('press');
  }

  lightClick($event: MouseEvent) {
    if (!this.pressed) {
      console.log('click');
    } else {
      this.pressed = false;
    }
  }

}
