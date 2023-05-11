import { Component, Input } from '@angular/core';
import { Product } from 'src/app/model/product';
import { CartComponent } from '../cart/cart.component';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { Orders } from 'src/app/model/orders';
import { OrdersDetails } from 'src/app/model/orderDetails';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chekout',
  templateUrl: './chekout.component.html',
  styleUrls: ['./chekout.component.css'],
  providers: [CartComponent]
})
export class ChekoutComponent {

  private readonly key = 'cart';
  products: Product[] = [];
  prod : Product;
  userID = this.userAuthService.getUserID()


  constructor(readonly cartComponent: CartComponent, public DECservice : DECommerceApiService, public userAuthService : UserAuthService, private router : Router) { }

  ngOnInit(): void {
    this.products = this.getCartProducts();
    this.cartComponent.calculateTotal()
  }

  private getCartProducts(): Product[] {
    const storedProducts = localStorage.getItem(this.key);
    if (storedProducts) {
      return JSON.parse(storedProducts);
    } else {
      return [];
    }
  }
  //input dati per order e orderdetails
  @Input()
  email: string
  address : string
  country : string
  state : string
  cap : number
  city : string

  //remove item da carrello
   onCheckout(){
    // usiamo il costruttore per richiamare order e order details
     const order = new Orders()
        order.userID = this.userID
        order.totalPrice = this.cartComponent.calculateTotal()
        order.field1 = this.email
        order.field2 = this.address
        order.field3 = this.country
        order.field4 = this.state
        order.field7 = this.cap
        order.field5 = this.city

      const orderDetails = this.getCartProducts().map(item => {
        const detail = new OrdersDetails();
        detail.productID = item.productID;
      return detail;
      });
    // richiamiamo il metodo del service
     this.DECservice.checkout(order, orderDetails).subscribe(res =>{
       console.log(res)
     })

   }

   loading = false;
  success = false;

  acquisto() {
    // Mostra il modal di caricamento
    this.loading = true;

    // Simula un caricamento di 5 secondi
    setTimeout(() => {
      // Nasconde il modal di caricamento
      this.loading = false;

      // Mostra il modal di conferma acquisto
      this.success = true;
    }, 2000);

  }

  onIemoveItems(){
      //rimuoviamo i cart item
      this.cartComponent.removeAllItems()
  }

  goToYourOrder() {
    this.router.navigate(['/customer', this.userID, 'yourOrder']);
  }

   //-----------------------------------------------------------------------------------------------todo-----------------------------------------------------------------------------------------------------------

}
