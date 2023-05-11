import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DECommerceApiService } from './decommerce-api.service';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {


  admin : boolean;
  role : any;
  constructor(private decommerceApiService : DECommerceApiService, private http : HttpClient) { }

  //login method
  //importo l'url dell'api
  login(username : string, password : string) :Observable<any>{
    const body = { username: username, password: password };
    return this.http.post(this.decommerceApiService.DECommerceAPIUrl + '/auth' + '/login', body)
  }

  public setRole(role : string) {
    localStorage.setItem('ruolo', role);
  }

  public getRole() {
    return localStorage.getItem('ruolo');
  }

  public isAdmin() {
    this.role = localStorage.getItem('ruolo')
    if(this.role == 2){
      return this.admin = true
    }else{
    return this.admin = false
    }
  }

  public setToken(jwtToken: string) {
    localStorage.setItem('token', jwtToken);
  }

  public getToken(): string {
    return localStorage.getItem('token')!;
  }

  public logOut() {
    return localStorage.clear();
  }

  public isLoggedIn() {
    return this.getRole() && this.getToken();
  }

  //set user nel localstorage
  public setUser(userID : string) {
    localStorage.setItem('userID', userID);
  }

  public getUserID() {
    return localStorage.getItem('userID')!;
  }
}
