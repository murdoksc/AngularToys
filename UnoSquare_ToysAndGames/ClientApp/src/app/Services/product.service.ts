import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ProductDetail } from './../models/product.model';



const baseUrl = 'https://localhost:44331/api/ToysGames';
@Injectable({
  providedIn: 'root' 
})
export class ProductDetailService {
  constructor(private http: HttpClient) {

  }
  //normal methods
  getAll() {
    return this.http.get<ProductDetail[]>(baseUrl);
  }

  get(id) {
    return this.http.get<ProductDetail>(`${baseUrl}/${id}`);
  }

  create(data) {
    return this.http.post(baseUrl, data);
  }

  update(data) {
    return this.http.put(baseUrl, data);
  }
  //async method example
  async delete(id) {
    return await this.http.delete(`${baseUrl}/${id}`);
  }
}

