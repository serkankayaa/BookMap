import { RegisterComponent } from './components/register/register.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AuthorComponent } from './components/author/author.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BookComponent } from './components/book/book.component';
import { ShopComponent } from './components/shop/shop.component';
import { PublisherComponent } from './components/publisher/publisher.component';
import { CategoryComponent } from './components/category/category.component';
import { SupplierComponent } from './components/supplier/supplier.component';


const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent, },
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