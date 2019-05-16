import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AuthorComponent } from './author/author.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BookComponent } from './book/book.component';
import { ShopComponent } from './shop/shop.component';
import { PublisherComponent } from './publisher/publisher.component';
import { CategoryComponent } from './category/category.component';
import { SupplierComponent } from './supplier/supplier.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'book', component: BookComponent },
  { path: 'publisher', component: PublisherComponent },
  { path: 'author', component: AuthorComponent },
  { path: 'shop', component: ShopComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'supplier', component: SupplierComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }