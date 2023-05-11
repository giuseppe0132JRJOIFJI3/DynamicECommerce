import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { CatalogComponent } from '../../catalog/catalog.component';
import { CustomerComponent } from '../../users/customer/customer/customer.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  providers: [UserAuthService]

})
export class NavbarComponent {

  id:string


  constructor(public catalogComponent : CatalogComponent ,public userAuthService : UserAuthService, private router : Router){}

  IsAuthenticated(){
    return this.userAuthService.isLoggedIn()
  }

  onLogout(){
    this.userAuthService.logOut(),
    this.router.navigate(['/home']);
  }

  ngOnInit(): void {
    this.id =this.userAuthService.getUserID();
  }

  //dirottamento se sei admin o customer quando si clicca sull'icona
  goProfile(){
    switch(this.userAuthService.getRole()){
      case '1':
        this.userAuthService.getRole() == '1'
        this.router.navigate(['/admin']);
        break
      case '2':
        this.userAuthService.getRole() == '2'
        this.router.navigate(['/customer/'+ this.id])
    }
  }
}
