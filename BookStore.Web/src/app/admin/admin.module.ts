import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminShopComponent } from './admin-shop/admin-shop.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminBookComponent } from './admin-book/admin-book.component';
import { AdminAuthorComponent } from './admin-author/admin-author.component';
import { AdminPublisherComponent } from './admin-publisher/admin-publisher.component';
import { AdminSupplierComponent } from './admin-supplier/admin-supplier.component';
import { AdminCategoryComponent } from './admin-category/admin-category.component';

@NgModule({
  declarations: [AdminShopComponent, AdminDashboardComponent, AdminBookComponent, AdminAuthorComponent, AdminPublisherComponent, AdminSupplierComponent, AdminCategoryComponent],
  imports: [
    CommonModule,
    AdminRoutingModule
  ],
})
export class AdminModule { }
