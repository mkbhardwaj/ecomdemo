import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';
import { ShopParams } from '../shared/models/shopparams';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { environment } from 'src/environments/environment';
import { IProduct } from '../shared/models/product';
// services are singleton that means they are available all the time till our application is running.

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = environment.baseUri;
  constructor(private http: HttpClient) { }

  getProducts(shopParam: ShopParams) {
    let params = new HttpParams();
    if (shopParam.brandId !== 0) {
      params = params.append('brandId', shopParam.brandId.toString());
    }

    if (shopParam.typeId !== 0) {
      params = params.append('typeId', shopParam.typeId.toString());
    }

    if (shopParam.search) {
      params = params.append('search', shopParam.search.toString());
    }
    params = params.append('sort', shopParam.sort);
    params = params.append('pageIndex', shopParam.pageNumber.toString());
    params = params.append('pageSize', shopParam.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl + 'products', {

      observe: 'response',
      params,
    }).pipe(
      map(
        response => {
          return response.body;
        }
      ));
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }
}
