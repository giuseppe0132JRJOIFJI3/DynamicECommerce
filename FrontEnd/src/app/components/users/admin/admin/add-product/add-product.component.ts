import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from 'src/app/model/product';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

declare var $: any; // dichiara la variabile $ di jQuery

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})

export class AddProductComponent implements OnInit{

  product: Product = new Product();
  selectedFile!: File

  addProductForm : FormGroup;
  categoryList$: Observable<any>;
  selectedCategory: string;
  selectedCategoryId: string;
  showModal : boolean = false;

  constructor(private DECservice : DECommerceApiService, private router : Router) { }

  onFileSelected(event:any) {
    this.selectedFile = <File>event.target.files[0];
  }

  onAddProduct() {
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    fd.append('productCategoriesID', this.product.productCategoriesID);
    fd.append('unitPrice', this.product.unitPrice);
    fd.append('field1', this.product.field1);
    fd.append('field2', this.product.field2);
    fd.append('field4', this.product.field4);
    //console log

    this.DECservice.createProducts(fd).subscribe(() => {
      this.showModal = true; // mostra il pop-up
      this.addProductForm.reset();
    });
  }

  ngOnInit(): void {
    this.categoryList$ = this.DECservice.getCategory();
    this.validationForm();
    console.log(this.categoryList$)
  }

  onSelectCategory(event: Event) {
    const target = event.target as HTMLSelectElement;
    this.product.productCategoriesID = target.value;
  }

  validationForm(){
    this.addProductForm = new FormGroup({
      selectedCategoryFormControl : new FormControl(null, Validators.required),
      unitPriceFormControl : new FormControl(null, Validators.required),
      field1FormControl : new FormControl(null, Validators.required),
      field2FormControl : new FormControl(null, Validators.required),
    })
  }

  closePopup() {
    document.querySelector('.modal')!.classList.remove('show');
    this.showModal = false; // nasconde il pop-up
  }
}
