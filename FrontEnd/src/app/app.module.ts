import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home/home.component';
import { CustomerComponent } from './components/users/customer/customer/customer.component';
import { AdminComponent } from './components/users/admin/admin/admin.component';
import { LoginComponent } from './components/login/login/login.component';
import { SignInComponent } from './components/login/sign-in/sign-in.component';
import { NavbarComponent } from './components/navbar/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddProductComponent } from './components/users/admin/admin/add-product/add-product.component';
import { AddCategoryComponent } from './components/users/admin/admin/add-category/add-category.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { ProductDetailsComponent } from './components/catalog/product-details/product-details.component';
import { CartComponent } from './components/cart/cart.component';
import { ChekoutComponent } from './components/chekout/chekout.component';
import { SuccessPopupComponent } from './components/success-popup/success-popup.component';
import { OrderComponent } from './components/users/customer/customer/order/order.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { FooterComponent } from './components/footer/footer.component';







@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomerComponent,
    AdminComponent,
    LoginComponent,
    SignInComponent,
    NavbarComponent,
    AddProductComponent,
    AddCategoryComponent,
    CatalogComponent,
    ProductDetailsComponent,
    CartComponent,
    ChekoutComponent,
    SuccessPopupComponent,
    OrderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CarouselModule
  ],
  providers: [CatalogComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
