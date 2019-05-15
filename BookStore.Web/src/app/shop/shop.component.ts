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
  shopList: Shop[];
  isEdit = false;

  constructor(private shopService: ShopService, private toastrService: ToastrService) { }

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
        this.toastrService.success('Shop added successfully');
        this.shop = new Shop();
        this.getShops();
        this.refreshForm();

        return;
      }
      if (response.body === false) {
        this.toastrService.error('This shop added already');
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

  editShop(selectedShop: Shop): void {
    this.shop = selectedShop;
    this.isEdit = true;
  }

  updateShop(): void {
    const result = this.shopService.updateShop(this.shop).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Shop edited successfully.');
          this.getShops();
          this.refreshForm();
          this.shop = new Shop();
          this.isEdit = false;
        }
        if (res.body === false) {
          this.toastrService.error('Please make a change to edit.');
          this.focusErrorInput();
          return;
        }
      });
  }

  deleteShop(id: any): void {
    this.shopService.deleteShop(id).subscribe((res) => {
      {
        this.toastrService.success('Shop deleted successfully.');
        this.getShops();
        this.refreshForm();
        this.shop = new Shop();
        this.isEdit = false;
      }
    });
  }

  cancelUpdate() {
    this.shop = new Shop();
    this.isEdit = false;
    this.getShops();
    this.refreshForm();
  }

}
