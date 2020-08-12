import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { Router, ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: IProduct;
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute,
              private breadcrumbService: BreadcrumbService) {
      this.breadcrumbService.set('@productDetails' , '');
    }

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(response => {
      this.product = response;
      this.breadcrumbService.set('@productDetails' , this.product.name);
    }, error => {
      console.log(error);
    });
    }
}
