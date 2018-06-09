import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'shared-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  public isMobile: Boolean = /mobile/i.test(navigator.userAgent);

  private _menu_items: any[] = [
    {
      'title': 'Início',
      'link': '/figurinhas',
      'fragment': 'inicio',
      'unique': true
    }
  ];

  constructor() { }

  ngOnInit() {
  }

  get menu_items() {
    return this._menu_items;
  }

}
