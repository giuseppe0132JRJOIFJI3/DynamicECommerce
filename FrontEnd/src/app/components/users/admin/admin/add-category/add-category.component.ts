import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfigurationServicService } from 'src/app/services/configuration-servic.service';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit{

  nameComponent = 'AddCategoryComponent';
  addCategoryForm: FormGroup
  showModal : boolean = false;


  constructor(private DECservice : DECommerceApiService, public configurationService : ConfigurationServicService) { }

  selectedFile!: File

  @Input()
  ProductCategoriesID: number;
  Field1: string= '';
  Field2: string = '';
  Field3: string='';


  onFileSelected(event:any) {
    this.selectedFile = <File>event.target.files[0];
  }


  onAddProductCategory() {
    const fd = new FormData();
    fd.append('field1', this.selectedFile, this.selectedFile.name);
    fd.append('field2', this.Field2);
    fd.append('field3', this.Field3);

    //console log
      this.DECservice.createCategory(fd).subscribe(res => {
        this.showModal = true; // mostra il pop-up
        this.addCategoryForm.reset();
    }
  )}

  validationForm(){
    this.addCategoryForm = new FormGroup({
      categoryNameFormControl : new FormControl(null, Validators.required),
    })
  }

  ngOnInit(): void {
    this.validationForm();
  }

  closePopup() {
    document.querySelector('.modal')!.classList.remove('show');
    this.showModal = false; // nasconde il pop-up
  }
}

