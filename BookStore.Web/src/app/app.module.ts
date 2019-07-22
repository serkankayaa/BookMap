import { DashboardService } from './services/dashboard.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AdminModule } from './admin/admin.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { AuthorService } from './services/author.service';
import { CategoryService } from './services/category.service';
import { PublisherService } from './services/publisher.service';
import { ShopService } from './services/shop.service';
import { BookService } from './services/book.service';
import { DocumentService } from './services/document.service';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    AdminModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [AuthorService, PublisherService, ShopService, CategoryService, BookService, DocumentService, DashboardService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
