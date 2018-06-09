import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-figurinhas',
  templateUrl: './figurinhas.component.html',
  styles: []
})
export class FigurinhasComponent implements OnInit {

  public isMobile: Boolean = /mobile/i.test(navigator.userAgent);

  constructor() { }

  ngOnInit() {
  }

}
