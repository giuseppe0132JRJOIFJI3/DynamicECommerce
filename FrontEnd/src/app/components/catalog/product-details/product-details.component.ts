import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/model/product';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { CartComponent } from '../../cart/cart.component';
import { ConfigurationServicService } from 'src/app/services/configuration-servic.service';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { OwlOptions } from 'ngx-owl-carousel-o';


@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
  providers: [CartComponent]
})
export class ProductDetailsComponent implements OnInit{


  // Other properties and methods for your component
  // ...

  nameComponent : string = 'ProductDetailsComponent'
  product : any
  relatedProducts : any
  productID = this.route.snapshot.paramMap.get('productID')
  i : any
  index: boolean = true;

  constructor(private DECservice : DECommerceApiService, private route : ActivatedRoute, readonly cartComponent: CartComponent, public configurationService : ConfigurationServicService, public userAuthService : UserAuthService){}

  ngOnInit() {
    this.onGetProductByProductID()
    // this.onGetProductsByCategoriesID()
    console.log(this.product)
  }


  //get singlke product
  onGetProductByProductID(){
    this.DECservice.getProductByProductID(this.productID).subscribe((productData)=>{
      this.product = productData;
      console.log(productData)
      //richiamo il metodo per ottenere i prodotti in base alla categoria del prodotto in dettaglio direttamente in questo metodo cosi passo il productCategoriesID direttamente
      this.onGetProductsByCategoriesID();
    })
  }
  //add to chart
  OnAddProduct(): void {

    this.DECservice.getProducts().subscribe( (data:any) => {

      this.product = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )
  }

  //mostrare solo i prodotti in base alla categoria
  onGetProductsByCategoriesID(){
    this.DECservice.getProductsByCategoriesID(this.product.productCategoriesID).subscribe((prod) => {
      //assegna i prodotti filtrati alla proprietà 'products' del componente
      this.relatedProducts = prod;
      console.log(prod)
    });
  }


}

