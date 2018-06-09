import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'figurinhas-banner',
  templateUrl: './banner.component.html',
  styles: []
})
export class FigurinhasBannerComponent implements OnInit {

  private _carousel_items: any[] = [
    {
      'link': 'assets/img/slider/bg-1.jpg',
      'show_title': false,
      'text_one': 'Impression - Startup Event',
      'text_two': 'Join us be The First to Book Your Ticket',
      'link_text': 'Reservar',
      'link_url': '/figurinhas',
      'link_fragment': 'reserve'
    }
  ];

  constructor() { }

  ngOnInit() {
  }

  get carousel_items() {
    return this._carousel_items;
  }

}
