import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, forkJoin, switchMap } from 'rxjs';
import { Orders } from '../model/orders';
import { OrdersDetails } from '../model/orderDetails';


@Injectable({
  providedIn: 'root'
})
export class DECommerceApiService {

  //connection url
  readonly DECommerceAPIUrl = "https://localhost:7098/api";

  constructor(private http : HttpClient) { }

  //-----------------------------------users--------------------------------------
  //add user
  addUsers(data : any){
    return this.http.post(this.DECommerceAPIUrl + '/users', data);
  }

  getUser(userID : any){
    return this.http.get(this.DECommerceAPIUrl + '/Users/User'+ userID + '?userID=' + userID);
  }

  //-----------------------------------products--------------------------------------
  //add product
  createProducts(data: any) {
    return this.http.post(this.DECommerceAPIUrl + '/products', data);
  }

  getProducts() {
    return this.http.get(this.DECommerceAPIUrl + '/products');
  }

  getProductByProductID(productID : any) {
    return this.http.get(this.DECommerceAPIUrl + '/Products/ProductID' + productID + '?productID=' + productID);
    //localhost:7098/api/Products/ProductID1146?productID=1146
  }

  getProductsByCategoriesID(categoryID : any){
    return this.http.get(this.DECommerceAPIUrl + '/Products/ProductCategoriesID' + categoryID + '?productCategoriesID=' + categoryID);
  }

  //-----------------------------------category--------------------------------------
  //get category
  getCategory() {
    return this.http.get<any>(this.DECommerceAPIUrl + '/ProductCategories');
  }

  createCategory(data : any){
    return this.http.post(this.DECommerceAPIUrl + '/ProductCategories', data)
  }

  //-----------------------------------checkout--------------------------------------

   checkout(order: Orders, orderDetails: OrdersDetails[]): Observable<any> {
     return this.http.post<any>(this.DECommerceAPIUrl + '/Orders' , order).pipe(
       switchMap(response => {
        console.log(response)
         const orderID = response;
         orderDetails.forEach(detail => detail.orderID = orderID);
         const requests = orderDetails.map(detail => this.http.post<any>(this.DECommerceAPIUrl + '/OrdersDetails', detail));
         return forkJoin(requests);
       })
     );
   }

  //-----------------------------------order----------------------------------------------
  getOrders(userID : any){
    return this.http.get(this.DECommerceAPIUrl + '/Orders/UserID' + userID +'?userID=' + userID)
  }
  // checkouts(order: Orders): Observable<any> {
  //   return this.http.post<any>(this.DECommerceAPIUrl + '/Orders' , order)
  // }
  // chekoutOrderDetail(orderDetail : OrdersDetails[]): Observable<any> {
  //   return this.http.post<any>(this.DECommerceAPIUrl + '/OrdersDetails' , orderDetail)
  // }

}
