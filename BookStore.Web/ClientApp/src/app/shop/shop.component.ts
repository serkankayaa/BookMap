import { Shop } from './../models/shop';
import { ShopService } from './../services/shop.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
// import {  } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  shop = new Shop();
  shopList;

  constructor(private shopService: ShopService, private toasterService: ToastrService) { }

  ngOnInit() {
    this.getShops();
  }

  refreshForm(): void {
    const dirtyFormID = 'shopForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  postShop(): object {
    const result = this.shopService.postShop(this.shop).subscribe((response) => {
      console.log(response);
      if (response.body != null && response.ok && response.body !== false) {
        this.toasterService.success('Shop added successfully');
        this.shop = new Shop();
        this.getShops();
        this.refreshForm();

        return;
      }
      if (response.body === false) {
        this.toasterService.error('This shop added already');
        this.focusErrorInput();
        return;
      }
    });

    return result;
  }

  focusErrorInput() {
    const dirtyFormID = 'shopName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  getShops(): void {
    this.shopService.getAllShops().subscribe(data => this.shopList = data);
  }
}
