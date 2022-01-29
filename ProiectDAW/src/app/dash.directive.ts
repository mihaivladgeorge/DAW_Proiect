import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appDash]'
})
export class DashDirective {

  constructor(private el: ElementRef) {}

   @HostListener('mouseenter') onMouseEnter() {
     this.transform('scale(1.2, 1.2)');
   }

   @HostListener('mouseleave') onMouseLeave() {
     this.transform('scale(1, 1)');
   }

   private transform(type: string) {
     this.el.nativeElement.style.transform = type;
   }

}
