import { DOCUMENT } from '@angular/common';
import { Component, HostListener, Inject, Injectable, OnInit } from '@angular/core';

@Component({
  selector: 'app-scrollToTop',
  templateUrl: './scrollToTop.component.html',
  styleUrls: ['./scrollToTop.component.css']
})
@Injectable()

export class ScrollToTopComponent {

  windowScrolled: boolean;

  constructor(@Inject(DOCUMENT) private document: Document) { }


  @HostListener("window:scroll", [])
  onWindowScroll() {
    if (window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop > 100) {
      this.windowScrolled = true;
    }
    else if (this.windowScrolled && window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop < 10) {
      this.windowScrolled = false;
    }
  }
  scrollToTop() {
    (function smoothscroll() {
      var currentScroll = document.documentElement.scrollTop || document.body.scrollTop;
      if (currentScroll > 0) {
        window.requestAnimationFrame(smoothscroll);
        window.scrollTo(0, currentScroll - (currentScroll / 8));
      }
    })();
  }


}
