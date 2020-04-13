import { Component, OnInit } from '@angular/core';
import { ProductDetailService } from '../Services/product.service';
import { Router } from "@angular/router";
import { ProductDetail } from '../models/product.model';

@Component({
  selector: 'toys-data',
  templateUrl: './toys.component.html'
})
export class ToysComponent implements OnInit {
  constructor(private service: ProductDetailService,private router: Router) { }
  private products: ProductDetail[];
 
  ngOnInit() {
    window.localStorage.setItem("productid", null);
    this.GetAllProducts();
  }

  GetAllProducts() {
    this.service.getAll().subscribe(data => {
      this.products = data;
    });
  }

  async deleteProduct(product: ProductDetail) {
    if (confirm("Are you sure to delete Product " + product.name)) {
      (await this.service.delete(product.id)).subscribe(()=> this.GetAllProducts());
     
    }
  }

  UpdateProduct(productid: string): void {
    window.localStorage.setItem("productid", productid);
    this.router.navigate(['product']);
    };
} 


