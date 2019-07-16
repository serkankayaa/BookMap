import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';

import { AdminShopComponent } from './admin-shop/admin-shop.component';
import { AdminBookComponent } from './admin-book/admin-book.component';
import { AdminCategoryComponent } from './admin-category/admin-category.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminPublisherComponent } from './admin-publisher/admin-publisher.component';
import { AdminSupplierComponent } from './admin-supplier/admin-supplier.component';
import { AdminAuthorComponent } from './admin-author/admin-author.component';

const routes: Routes = [
  { path: '', component: AdminDashboardComponent },
  { path: 'author', component: AdminAuthorComponent },
  { path: 'shop', component: AdminShopComponent },
  { path: 'book', component: AdminBookComponent },
  { path: 'category', component: AdminCategoryComponent },
  { path: 'dashboard', component: AdminDashboardComponent },
  { path: 'publisher', component: AdminPublisherComponent },
  { path: 'supplier', component: AdminSupplierComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AdminRoutingModule { }
