import { Shop } from './../models/shop';
import { ShopService } from './../services/shop.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  shop = new Shop();
  shopList;

  constructor(private shopService : ShopService, private toasterService : ToastrService) { }

  ngOnInit() {
    this.getShops();
  }

  postShop() : object{
    const result = this.shopService.postShop(this.shop).subscribe((response) => { 
      console.log(response);
      if(response.body != null && response.ok && response.body != false){
        this.toasterService.success("Shop added successfully");
        this.shop = new Shop();
        this.getShops();

        return;
      }
      if(response.body ==false) {
        this.toasterService.error("This shop added already");
        return;
      }
    });

    return result;
  }

  getShops() : void {
    this.shopService.getAllShops().subscribe(data => this.shopList = data);
  }
}
