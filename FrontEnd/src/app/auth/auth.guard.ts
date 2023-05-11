import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanActivateChildFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { DECommerceApiService } from '../services/decommerce-api.service';
import { UserAuthService } from '../services/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate{

  constructor(private userAuthService: UserAuthService, private router: Router, private srvice: DECommerceApiService, private http : HttpClient){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean{
      if(this.userAuthService.isLoggedIn())
      {
        return true
      }
      alert("Yhou have not logged in")
      this.router.navigate(['/login'])
      return false;
  }
}


