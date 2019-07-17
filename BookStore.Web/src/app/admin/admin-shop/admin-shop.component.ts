import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Shop } from '../../models/shop';

@Component({
  selector: 'app-admin-shop',
  templateUrl: './admin-shop.component.html',
  styleUrls: ['./admin-shop.component.css']
})
export class AdminShopComponent implements OnInit {
  public formSubmitted = false;
  public shop = new Shop();
  public Shops: Shop[];
  public shopForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.shopForm = this.fb.group({
      shop: ['', Validators.required],
      location: ['', Validators.required]
    });
  }

  get form() {
    return this.shopForm.controls;
  }

  submitShop() {
    this.formSubmitted = true;
    if (this.shopForm.invalid) {
      return;
    }
    console.log(this.shop);
  }
}
