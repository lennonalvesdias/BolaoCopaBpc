import { AuthService } from './../../auth/auth.service';
import { Component, OnInit } from '@angular/core';
declare var nowuiKit: any;
declare var $: any;
declare var scroll_distance: any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(
    private _auth: AuthService
  ) { }

  ngOnInit() {
    scroll_distance = $('.navbar[color-on-scroll]').attr('color-on-scroll');
    nowuiKit.checkScrollForTransparentNavbar();
    $(window).on('scroll', nowuiKit.checkScrollForTransparentNavbar);
  }

  sair() {
    this._auth.sair();
  }

}
