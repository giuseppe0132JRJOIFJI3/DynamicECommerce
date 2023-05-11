import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { DECommerceApiService } from './decommerce-api.service';
import { Configuration } from '../model/configuration';
import { UserAuthService } from './user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationServicService{

  constructor(private http : HttpClient, private DECservice : DECommerceApiService) { }

  configuration : Configuration;

  initialize(){
    //TODO RETURN DEVE DIVENTARE UNA VARIABILE, A CUI POI ACCEDIAMO RICHIAMANDO IL SERVICE IN TUTTI I COMPONENTI
     this.http.get(this.DECservice.DECommerceAPIUrl + '/Configurations').subscribe((x : any)=>{
      this.configuration = x;
     }
     );

  }

 isVisible(componentName:string, fieldName:string)
 {
  let isVisible =  this.configuration?.pages.find(x=> x.name === componentName)?.fields.find(x=> x.name == fieldName)?.isVisible;

  return isVisible;
 }

 getText(componentName:string, fieldName:string)
 {
  let text=  this.configuration.pages.find(x=> x.name === componentName)?.fields.find(x=> x.name == fieldName)?.text;

  return text;
 }

}
