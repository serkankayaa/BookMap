import { ShopService } from './services/shop.service';
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

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AuthorComponent,
    NavbarComponent,
    BookComponent,
    PublisherComponent,
    ShopComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    HttpModule,
    [AgGridModule.withComponents(AuthorComponent)],
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [HttpClientModule, AuthorService, PublisherService,ShopService],
  bootstrap: [AppComponent]
})
export class AppModule {  
}
