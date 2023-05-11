import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { DECommerceApiService } from '../services/decommerce-api.service';
import { UserAuthService } from '../services/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class HasCustomerGuard implements CanActivate {

  constructor(private userAuthService: UserAuthService, private router: Router, private srvice: DECommerceApiService){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
    {
      let roleId = this.userAuthService.getRole();
      if(roleId == '2')
    {
      return true;
    }
    alert("You don't have rights to access at this page")
    return false
    }

}
