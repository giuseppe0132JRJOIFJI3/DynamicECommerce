import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { LoginComponent } from '../login/login.component';
import { UserModel } from 'src/app/model/user.model';
import { Customer } from 'src/app/model/customer';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit{

  signUpForm : FormGroup;

  constructor(private decommerceService : DECommerceApiService, private userAuthService : UserAuthService, private route : ActivatedRoute, private router: Router){}

  customerModel: Customer = new Customer();
  // name : string ;
  // surname : string;
  // username : string;
  // password : string;
  profileImage! : File
  // birthdate : Date;


  onFileSelected(event:any) {
    this.profileImage = <File>event.target.files[0];
  }

  OnAddUser(){
    // crea un oggetto FormData
    const fd = new FormData();
    fd.append('name', this.customerModel.name);
    fd.append('surname', this.customerModel.surname);
    fd.append('username', this.customerModel.username);
    fd.append('password', this.customerModel.password);
    fd.append('FIeld2', this.profileImage, this.profileImage.name);
    fd.append('field3', this.customerModel.field3);


    this.decommerceService.addUsers(fd).subscribe(res =>{
      console.log(res)
    })
  }


  validationForm(){
    this.signUpForm = new FormGroup({
      name : new FormControl(null, Validators.required),
      surname : new FormControl(null, Validators.required),
      birthdate : new FormControl(null, Validators.required),
      username : new FormControl(null, Validators.required),
      password : new FormControl(null, Validators.required),
    })
  }



  ngOnInit(): void {
    this.validationForm();
  }

}
