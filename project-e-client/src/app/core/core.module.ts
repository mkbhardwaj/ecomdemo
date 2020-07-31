import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestErrorComponent } from './test-error/test-error.component';
import { ToastrModule } from 'ngx-toastr';
// create different module to handler different part core module will handle all the common features

@NgModule({
  declarations: [NavBarComponent, NotFoundComponent, ServerErrorComponent, TestErrorComponent],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
    positionClass: 'toast-bottom-right',
    preventDuplicates: true
  }),
  RouterModule
  ],
  exports: [NavBarComponent ]
})
export class CoreModule { }
