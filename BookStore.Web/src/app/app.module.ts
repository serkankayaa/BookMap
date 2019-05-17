import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AgGridModule } from 'ag-grid-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';


import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AuthorComponent } from './author/author.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BookComponent } from './book/book.component';
import { PublisherComponent } from './publisher/publisher.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthorService } from './services/author.service';
import { PublisherService } from './services/publisher.service';
import { ShopComponent } from './shop/shop.component';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from './services/category.service';
import { SupplierComponent } from './supplier/supplier.component';
import { SupplierService } from './services/supplier.service';
import { ShopService } from './services/shop.service';
import { SignInComponent } from './sign-in/sign-in.component';
import { JwtService } from './services/jwt.service';
import { RegisterComponent } from './register/register.component';
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
      RegisterComponent
   ],
   imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      // tslint:disable-next-line: deprecation
      HttpModule,
      [AgGridModule.withComponents(AuthorComponent)],
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
   ],
   providers: [HttpClientModule, AuthorService, PublisherService, ShopService, CategoryService, SupplierService, JwtService],
   bootstrap: [AppComponent]
})
export class AppModule {
}
