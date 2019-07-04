import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';



import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AuthorService } from './services/author.service';
import { CategoryService } from './services/category.service';
import { PublisherService } from './services/publisher.service';
import { ShopService } from './services/shop.service';
import { SupplierService } from './services/supplier.service';
import { BookService } from './services/book.service';
import { DocumentService } from './services/document.service';
import { AdminComponent } from './admin/admin.component';
import { AdminModule } from './admin/admin.module';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    AdminModule,
    HttpModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [HttpClientModule, AuthorService, PublisherService, ShopService, CategoryService, SupplierService, BookService, DocumentService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
