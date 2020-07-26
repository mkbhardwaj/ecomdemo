import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PaginHeaderComponent } from './pagin-header.component';
import { PagerComponent } from './pager/pager.component';


@NgModule({
  declarations: [PaginHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [
    PaginHeaderComponent,
    PagerComponent
  ]
})
export class SharedModule { }
