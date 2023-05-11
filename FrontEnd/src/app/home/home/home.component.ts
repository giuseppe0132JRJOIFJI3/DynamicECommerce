import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CatalogComponent } from 'src/app/components/catalog/catalog.component';
import { Product } from 'src/app/model/product';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {
    // id : string | undefined | null = "28"
    // singleProduct! : any
    products : any
    categories : any
    loop: boolean = true;
    i : any
    index: boolean = true;

    constructor(public catalogComponent : CatalogComponent, public DECservice: DECommerceApiService, private route : ActivatedRoute ) { }

    ngOnInit(): void {

      this.DECservice.getProducts().subscribe( (data:any) => {

      this.products = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )

    this.onGetCategory()
  }

    //get per estrarre i nomi delle categorie
    onGetCategory(){
      this.DECservice.getCategory().subscribe((cat)=>{
        this.categories = cat
      })
    }
}
