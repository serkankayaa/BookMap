import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AgGridModule } from 'ag-grid-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';


import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AuthorComponent } from './components/author/author.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BookComponent } from './components/book/book.component';
import { PublisherComponent } from './components/publisher/publisher.component';
import { AppRoutingModule } from './app-routing.module';
import { ShopComponent } from './components/shop/shop.component';
import { CategoryComponent } from './components/category/category.component';
import { SupplierComponent } from './components/supplier/supplier.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { RegisterComponent } from './components/register/register.component';

import { AuthorService } from './services/author.service';
import { CategoryService } from './services/category.service';
import { PublisherService } from './services/publisher.service';
import { ShopService } from './services/shop.service';
import { SupplierService } from './services/supplier.service';
import { BookService } from './services/book.service';
import { DocumentService } from './services/document.service';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      AuthorComponent,
      NavbarComponent,
      BookComponent,
      PublisherComponent,
      ShopComponent,
      CategoryComponent,
      SupplierComponent,
      SignInComponent,
      RegisterComponent,
   ],
   imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      HttpModule,
      [AgGridModule.withComponents(AuthorComponent)],
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
   ],
   providers: [HttpClientModule, AuthorService, PublisherService, ShopService, CategoryService, SupplierService, BookService,DocumentService],
   bootstrap: [AppComponent]
})
export class AppModule {
}
