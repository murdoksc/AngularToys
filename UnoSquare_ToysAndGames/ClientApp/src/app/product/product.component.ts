import { Component, OnInit } from '@angular/core';
import { ProductDetailService } from './../Services/product.service';
import { ProductDetail } from '../models/product.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from "@angular/router";

@Component({
  selector: 'add-product',
  templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
 
  Product: ProductDetail = { id: 0, name: '', description: '', ageRestriction: 0, company: '', price: 1 };
  submitted = false;
  constructor(private service: ProductDetailService, private fb: FormBuilder, private router: Router) { }
  isUpdate = false;
  productId = null;
  showMsg: boolean = false;

  //getting controls in form for reactive validation
  myForm = new FormGroup({})
  get f() { return this.myForm.controls; }
 
  ngOnInit() {
    this.productId = window.localStorage.getItem("productid");
    if (this.productId != "null") {
      this.isUpdate = true;
    }
    this.getProductData();

    //validations
    this.myForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      price: [1, [Validators.min(1), Validators.max(1000), Validators.required]],
      company: ['', [Validators.maxLength(50), Validators.required]],
      agerestriction: [1, [Validators.min(0), Validators.max(100)]],
      description: ['', [Validators.maxLength(100)]]
    });
  }


  getProductData() {
    this.service.get(this.productId).subscribe(data => {
      this.Product = data
    })
  }


  //if we have a productid then we are updating, otherwhise save new record
  saveProduct() {
    const data = {
      id : 0,
      name: this.Product.name,
      description: this.Product.description,
      ageRestriction: this.Product.ageRestriction,
      company: this.Product.company,
      price: this.Product.price 
    };
    try {
      if (this.isUpdate) {
        data.id = +this.productId;
        this.service.update(data).subscribe(
          response => {
            console.log(response);
            this.submitted = true;
          },
          error => {
            console.log(error);
          });
      } else {
        this.service.create(data)
          .subscribe(
            response => {
              console.log(response);
              this.submitted = true;
            },
            error => {
              console.log(error);
            });
      }
      this.showMsg = true;
      setTimeout(() => this.showMsg=false, 3000);
    } catch (e) {
      console.log(e);
    }
  }


  cancel() {
    this.router.navigate(['toys']);
  }
}



