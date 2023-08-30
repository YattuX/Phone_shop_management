import { ChangeDetectorRef, Component } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
@Component({
  selector: 'app-breadcrumb-carousel',
  templateUrl: './breadcrumb-carousel.component.html',
  styleUrls: ['./breadcrumb-carousel.component.css'],
  animations: [
    trigger('slideAnimation', [
      state('active', style({ opacity: 1, transform: 'translateX(0)' })),
      state('inactive', style({ opacity: 0, transform: 'translateX(-100%)' })),
      transition('inactive => active', animate('10s ease-in-out')),
      transition('active => inactive', animate('10s ease-in-out'))
    ])
  ]
})
export class BreadcrumbCarouselComponent {
  currentIndex = 1;
  carouselTransform = '';
  intervalId: any;
  active= true;
  constructor(private cdr: ChangeDetectorRef) { }

  slides = [

    // { title: 'Slide 1', image: '../../../../../assets/images/login_image.jpg' },
    { title: 'Slide 2', image: '../../../../../assets/images/luffy_profile.jpg' },
    // { title: 'Slide 3', image: '../../../../../assets/images/logo.png' },
  ];

  ngOnInit() {
    this.startAutoSlide();
  }

  ngOnDestroy() {
    this.stopAutoSlide();
  }

  startAutoSlide() {
    this.intervalId = setInterval(() => {
      this.goToSlide(this.currentIndex + 1);
      console.log(this.currentIndex);

    }, 1000); // 10 seconds interval
  }

  stopAutoSlide() {
    clearInterval(this.intervalId);
  }

  goToSlide(index: number) {
    if (index < 0) {
      index = this.slides.length - 1;
    } else if (index >= this.slides.length) {
      index = 0;
    }

    this.currentIndex = index;
    this.cdr.detectChanges()
    this.active =!this.active
  }
}
