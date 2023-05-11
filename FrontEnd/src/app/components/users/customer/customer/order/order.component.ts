import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from 'src/app/components/navbar/navbar/navbar.component';
import { CustomerComponent } from '../customer.component';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { UserAuthService } from 'src/app/services/user-auth.service';


@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [CustomerComponent, NavbarComponent]

})
export class OrderComponent implements OnInit{
  orders: any
  user: any

  constructor(public navbarComponent : NavbarComponent, public customerComponet : CustomerComponent, private DECservice : DECommerceApiService, public userAuthService : UserAuthService){}


  ngOnInit() {
    console.log(this.customerComponet.user)
    this.onGetOrders()

    this.DECservice.getUser(this.userAuthService.getUserID()).subscribe((userData)=>{
      this.user = userData;
      console.log(userData)
    })
  }

  onGetOrders(){
    this.DECservice.getOrders(this.userAuthService.getUserID()).subscribe((res =>{
      this.orders = res
      console.log(res)
    })
    )
  }
}
