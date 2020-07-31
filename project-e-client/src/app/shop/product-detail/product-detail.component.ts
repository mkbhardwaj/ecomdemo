import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: IProduct;
  constructor(private shopService: ShopService,private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(response=>{
      this.product = response;
    }, error => {
      console.log(error);
    });
    }
}
