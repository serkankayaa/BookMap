import { ShopService } from './../../services/shop.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Shop } from '../../models/shop';
declare var $: any;

@Component({
  selector: 'app-admin-shop',
  templateUrl: './admin-shop.component.html',
  styleUrls: ['./admin-shop.component.css']
})
export class AdminShopComponent implements OnInit {
  public formSubmitted = false;
  public shop = new Shop();
  public deleteShop = {};
  public editShop = {};
  public shopList: Shop[];
  public addShopForm: FormGroup;
  public editShopForm: FormGroup;

  constructor(private fb: FormBuilder,
    private shopService: ShopService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.addShopForm = this.fb.group({
      shop: ['', Validators.required],
      location: ['', Validators.required]
    });
    this.editShopForm = this.fb.group({
      shop: ['', Validators.required],
      location: ['', Validators.required]
    });
    this.getAllShops();
  }

  // Gets existed Shops
  getAllShops() {
    this.shopService.getAllShops().subscribe(shopData => {
      this.shopList = shopData;
    });
  }

  // Adds new Shop
  submitShop() {
    this.formSubmitted = true;
    if (this.addShopForm.invalid) {
      this.toastr.error(`Grrr! Please fill required fields!`, '', {
        closeButton: true,
        progressBar: true,
        progressAnimation: 'decreasing',
        timeOut: 4000
      });
      return;
    }

    this.shopService.postShop(this.shop).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Shop '${this.shop.ShopName}' successfully added!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllShops();
        $('#shopModal').modal('hide');
      }
    });
  }

  // Passes selected shop data and opens edit modal
  editModal(shop) {
    this.editShop = { ...shop };
    $('#editShopModal').modal('show');
  }

  // Updates the selected shop data
  updateShop(SelectedShop) {
    this.formSubmitted = true;
    if (this.editShopForm.invalid) {
      this.toastr.error(`Grrr! Please fill required fields!`, '', {
        closeButton: true,
        progressBar: true,
        progressAnimation: 'decreasing',
        timeOut: 4000
      });
      return;
    }
    
    this.shopService.updateShop(SelectedShop).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Shop '${SelectedShop.ShopName}' successfully updated!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllShops();
        $('#editShopModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#editShopModal').modal('hide');
      }
    });
  }

  // Passes selected shop data and opens delete modal
  deleteModal(shop) {
    this.deleteShop = { ...shop };
    $('#deleteShopModal').modal('show');
  }

  // Deletes the selected shop data
  deleteExistingShop(SelectedShop) {
    this.shopService.deleteShop(SelectedShop.ShopId).subscribe(res => {
      if (res) {
        this.toastr.success(`Shop '${SelectedShop.ShopName}' successfully deleted!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllShops();
        $('#deleteShopModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#deleteShopModal').modal('hide');
      }
    });
  }

  get form() {
    return this.addShopForm.controls;
  }
  get editform() {
    return this.editShopForm.controls;
  }
}
