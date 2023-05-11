import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/model/user.model';
import { DECommerceApiService } from 'src/app/services/decommerce-api.service';
import { Base64 } from 'js-base64';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm : FormGroup
  // user: UserModel;
  // user!: UserModel;


  constructor(private userAuthService : UserAuthService, private router: Router) {
    // this.user = this.getUser(this.userAuthService.getToken())
  }
  //redirect messaggio di errore
  loginError : boolean = false;


  onSubmit() {
    this.userAuthService.login(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe((response: any) => {
        this.userAuthService.setRole(response.roleId); console.log(response.roleId)
        this.userAuthService.setToken(response.token); console.log(response.token)
        const roleId = response.roleId;

        //caricamento user
        const userId = response.userID;
        this.userAuthService.setUser(userId);//set userID nel localstorage
        console.log(response)

        switch(roleId){
          case 1:
            roleId == '1'
            this.router.navigate(['/admin']);
            break;
          case 2:
            roleId == '2'
            this.router.navigate(['/customer/:userID']);
            break;
        }
    },
    error => {
      if (error instanceof HttpErrorResponse && error.status === 401) {
        this.loginError = true;
      }
    }
    );
  }

  initForm(){
    this.loginForm = new FormGroup ({
      username:new FormControl(null, Validators.required),
      password:new FormControl(null, Validators.required)
    })
  }

  // private getUser(token : string): UserModel{
  //   return JSON.parse(atob(token.split('.')[1])) as UserModel
  // }

  ngOnInit(): void {
    this.initForm()
  }
}

