import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NavbarComponent } from 'src/app/components/navbar/navbar/navbar.component';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { UserAuthService } from 'src/app/services/user-auth.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [NavbarComponent]

})
export class CustomerComponent implements OnInit{

  constructor(public navbarComponent : NavbarComponent, private userAuthService : UserAuthService, private router: Router, private DECservice : DECommerceApiService, private route : ActivatedRoute) {}
  userRole : any
  user : any
  userID = this.route.snapshot.paramMap.get('userID')
  id : any

  ngOnInit(): void {
    //prendo dal local storage lo userid e lo uso come imput per caricarmi tutti i dati dello user
    this.DECservice.getUser(this.userAuthService.getUserID()).subscribe((userData)=>{
      this.user = userData;
      console.log(userData)
    })
  }

  // onGetRole(){
  //   this.userAuthService.getRole().subscribe((roleData)=>{
  //     this.userRole = roleData;
  //     console.log(roleData)
  //   })

  }

