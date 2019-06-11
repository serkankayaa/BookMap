
import { Component, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { ShopService } from '../../services/shop.service';

import { Shop } from '../../models/shop';
declare var $: any;

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})

export class ShopComponent implements OnInit {
  shop = new Shop();
  allShops: Shop[];
  isEdit = false;
  shopId: any;
  hasData = true;

  constructor(private shopService: ShopService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAllShops();
  }

  getAllShops(): void {
    this.shopService.getAllShops().subscribe(data => {
      if (data.length === 0) {
        this.hasData = false;
      } else {
        this.hasData = true;
        this.allShops = data;
      }
    });
  }

  postShop(): object {
    const postedShop = this.shopService.postShop(this.shop).subscribe((response) => {
      console.log(response);
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Shop added successfully');
        this.shop = new Shop();
        this.getAllShops();
        this.refreshForm();

        return;
      }
      if (response.body === false) {
        this.toastrService.error('This shop added already');
        this.focusErrorInput();
        return;
      }
    });

    return postedShop;
  }

  focusErrorInput() {
    const dirtyFormID = 'shopName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }



  editShop(selectedShop: Shop): void {
    this.shop = selectedShop;
    this.isEdit = true;
  }

  updateShop(): void {
    this.shopService.updateShop(this.shop).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Shop edited successfully.');
          this.getAllShops();
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

  deleteShop(): void {
    this.shopService.deleteShop(this.shopId).subscribe((res) => {
      {
        this.toastrService.success('Shop deleted successfully.');
        this.getAllShops();
        this.refreshForm();
        this.shop = new Shop();
        this.isEdit = false;
        $('#deleteShop').modal('hide');
      }
    });
  }

  onDelete(id: any): void {
    $('#deleteShop').modal('show');
    this.shopId = id;
  }

  cancelUpdate() {
    this.shop = new Shop();
    this.isEdit = false;
    this.getAllShops();
    this.refreshForm();
  }

  refreshForm(): void {
    const dirtyFormID = 'shopForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }
}
