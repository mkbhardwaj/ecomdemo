import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
// create different module to handler different part core module will handle all the common features

@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule
  ],
  exports: [NavBarComponent]
})
export class CoreModule { }
