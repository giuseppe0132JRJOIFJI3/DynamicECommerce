import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';

class ImageSnippet {
  constructor(public src: string, public file: File) {}
}

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit{

  selectedFile: ImageSnippet;

  constructor(private DECservice : DECommerceApiService) { }

  ngOnInit(): void {

  }


  // processFile(field3: any) {
  //   const file: File = field3.files[0];
  //   const reader = new FileReader();

  //   reader.addEventListener('load', (event: any) => {

  //     let selectFileAsString;

  //     this.selectedFile = new ImageSnippet(event.target.result, file);
  //     // console.log(this.selectedFile);
  //     selectFileAsString = this.selectedFile.toString();
  //     console.log(selectFileAsString);
  //   });
  //    reader.readAsDataURL(file);
  // }
}
