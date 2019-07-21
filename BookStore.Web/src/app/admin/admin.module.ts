import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminShopComponent } from './admin-shop/admin-shop.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminBookComponent } from './admin-book/admin-book.component';
import { AdminAuthorComponent } from './admin-author/admin-author.component';
import { AdminPublisherComponent } from './admin-publisher/admin-publisher.component';
import { AdminCategoryComponent } from './admin-category/admin-category.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminSettingsComponent } from './admin-settings/admin-settings.component';



@NgModule({
  declarations: [AdminShopComponent, AdminDashboardComponent, AdminBookComponent, AdminAuthorComponent, AdminPublisherComponent, AdminCategoryComponent, AdminSettingsComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule.forRoot(),
  ],
})
export class AdminModule { }
