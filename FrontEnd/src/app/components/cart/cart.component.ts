import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/model/product';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent  implements OnInit {

  constructor(private DECservice : DECommerceApiService,   readonly route : ActivatedRoute) { }

  cartItems: any  = JSON.parse(localStorage.getItem('cart') || '[]');
  private key = 'cart';
  products = Product;
  cartProducts : Product[] = [];
  showPopup : boolean = false;

  ngOnInit(): void {
    const productId = this.route.snapshot.params[('productId')]; // get the id parameter from the URL
    this.DECservice.getProductByProductID(productId).subscribe(products => {
      this.cartProducts.push(productId);

      this.cartProducts = this.getCartProducts();
    });
  }

  getCartProducts(): Product[] {
    const storedProducts = localStorage.getItem(this.key);
    if (storedProducts) {
      return JSON.parse(storedProducts);
    } else {
      return [];
    }
  }

  saveCartProducts(cartProducts: Product[]): void {
    localStorage.setItem(this.key, JSON.stringify(cartProducts));
  }

  addToCart(product: Product): void {
    const cartProducts = this.getCartProducts();
    cartProducts.push(product);

    this.saveCartProducts(cartProducts);

    // Mostra un messaggio di successo
    this.showPopup = true;
    // Nascondi il messaggio di popup dopo 2 secondi
    setTimeout(() => {
      this.showPopup = false;
    }, 2000);
  }

  //metodo da richiamare per aggiornare la variabile cartItems del componente
  loadCartItems(){
    this.cartItems = JSON.parse(localStorage.getItem('cart') || '[]');
  }

  //metodo per rimuovere un elemento dal carrello, prende come parametro l'indice dell'elemento che si desidera rimuovere dall'array del carrello.
  removeItem(index: number) {
    this.cartItems.splice(index, 1);
    localStorage.setItem('cart', JSON.stringify(this.cartItems));
    this.loadCartItems();
    this.calculateTotal();
  }

  removeAllItems(){
    localStorage.removeItem('cart')
    this.loadCartItems();
    this.calculateTotal();
  }

  //metodo che serve per calcolare il totale, richiamicamo questo metodo ogni volta che rimuoviamo un oggetto dal carrello e nell' ngOnInit del checkoutComponent
  //metodo che ritorna un valore intero che sarebbe il totale
  calculateTotal() {
    let total = 0;
    for (let i = 0; i < this.cartItems.length; i++) {
      total += this.cartItems[i].unitPrice;
    }
    return total
  }
}
