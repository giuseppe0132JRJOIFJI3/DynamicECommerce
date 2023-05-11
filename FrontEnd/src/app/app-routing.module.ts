import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { HasRoleGuard } from './auth/has-admin.guard';
import { HasCustomerGuard } from './auth/has-customer.guard';
import { CatalogComponent } from './components/catalog/catalog.component';
import { ProductDetailsComponent } from './components/catalog/product-details/product-details.component';
import { ChekoutComponent } from './components/chekout/chekout.component';
import { LoginComponent } from './components/login/login/login.component';
import { SignInComponent } from './components/login/sign-in/sign-in.component';
import { AddCategoryComponent } from './components/users/admin/admin/add-category/add-category.component';
import { AddProductComponent } from './components/users/admin/admin/add-product/add-product.component';
import { AdminComponent } from './components/users/admin/admin/admin.component';
import { CustomerComponent } from './components/users/customer/customer/customer.component';
import { HomeComponent } from './home/home/home.component';
import { OrderComponent } from './components/users/customer/customer/order/order.component';

const routes: Routes = [
  {path: '', pathMatch: 'full',redirectTo : 'home'},

  //--------------------------------------------------catalogo-------------------------------------
  {
    path: 'catalog',
   component: CatalogComponent
  },
      {
        path: 'catalog/categoryID/:categoryID',
        component: CatalogComponent
      },
      {
        path: 'catalog/productID/:productID',
        component: ProductDetailsComponent
      },

  //--------------------------------------------------home-------------------------------------
  {
    path: 'home',
    component:HomeComponent,
  },

    //--------------------------------------login/registrazione----------------------------------

  {
    path: 'login',
   component: LoginComponent
  },
  {
    path: 'SignUp',
    component: SignInComponent
  },

  //--------------------------------------admin----------------------------------
  {
    path:'admin',
    component: AdminComponent,
    canActivate: [AuthGuard, HasRoleGuard],
  },
      {
        path:'admin/newProduct',
        component: AddProductComponent,
        canActivate : [AuthGuard, HasRoleGuard],
      },
      {
        path:'admin/newCategory',
        component: AddCategoryComponent,
        canActivate : [AuthGuard, HasRoleGuard],
      },


  //--------------------------------------customer----------------------------------
  {
    path:'customer/:userID',
    component: CustomerComponent,
    canActivate : [AuthGuard],
  },
      {
        path:'customer/:userID/yourOrder',
        component: OrderComponent,
        canActivate : [AuthGuard],
      },
      { path: 'customer/:userID/checkout',
      component: ChekoutComponent,
      canActivate: [AuthGuard, HasCustomerGuard]
      }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
