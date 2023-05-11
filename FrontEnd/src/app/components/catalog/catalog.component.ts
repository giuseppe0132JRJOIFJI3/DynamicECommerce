import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/model/product';
import { ConfigurationServicService } from 'src/app/services/configuration-servic.service';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent {
  nameComponent : string = 'CatalogComponent';
  products : any
  categories : any
  //paginazione
  currentPage: number = 1;
  productsPerPage: number = 8;

  constructor(private DECservice: DECommerceApiService, private route : ActivatedRoute, public configurationService: ConfigurationServicService) { }

  ngOnInit(): void {
    this.onGetProducts()

    this.onGetCategory()

    this.onGetCategory()
  }


  onGetProducts(){
    this.DECservice.getProducts().subscribe( (data:any) => {

      this.products = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )
  }


  //mostrare solo i prodotti in base alla categoria cliccata
  onGetProductsByCategoriesID(categoryID: any){
    this.DECservice.getProductsByCategoriesID(categoryID).subscribe((prod) => {
      // assegna i prodotti filtrati alla proprietà 'products' del componente
      this.products = prod;
      console.log(prod)
    });
  }

  //get nper estrarre i nomi delle categorie
  onGetCategory(){
    this.DECservice.getCategory().subscribe((cat)=>{
      this.categories = cat
    })
  }

  getDisplayedProducts(): Product[] {
    const startIndex = (this.currentPage - 1) * this.productsPerPage;
    const endIndex = startIndex + this.productsPerPage;
    return this.products.slice(startIndex, endIndex);
  }


  get pages(): number[] {
    const pageCount = Math.ceil(this.products.length / this.productsPerPage);
    return Array.from({ length: pageCount }, (_, i) => i + 1);
  }

  get totalPages(): number {
    return Math.ceil(this.products.length / this.productsPerPage);
  }

}
