import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { UserAuthService } from '../services/user-auth.service';
import { DECommerceApiService } from '../services/decommerce-api.service';



@Injectable({
  providedIn: 'root'
})
export class HasRoleGuard implements CanActivate {

  constructor(private userAuthService: UserAuthService, private router: Router, private srvice: DECommerceApiService){}

  canActivate(
    route : ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
  | Observable<boolean | UrlTree>
  | Promise<boolean | UrlTree>
  | boolean
  | UrlTree
  {
    let roleId = this.userAuthService.getRole();
      if(roleId == '1')
    {
      return true;
    }
    alert("You don't have admin rights")
    return false
  }
}
