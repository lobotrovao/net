import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '@core/dto/login-request';
import { AppUserAuth } from '@core/model/app-user-auth';
import { tap } from 'rxjs/operators';
import * as moment from 'moment';
import { LoginResponse } from '@core/dto/login-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private appUserAuth: AppUserAuth;

  constructor(private httpClient: HttpClient) { 
    this.appUserAuth = new AppUserAuth();
  }

  login(request: LoginRequest): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>('/AccountManager/Authenticate', request)
    .pipe(
      tap(resp => { 
          // Use object assign to update the current object
          // NOTE: Don't create a new AppUserAuth object
          //       because that destroys all references to object
          Object.assign(this.appUserAuth, resp);
          
          // Store into local storage
          localStorage.setItem("id_token", this.appUserAuth.token);
      })
    );
  }        

  logout() {
      localStorage.removeItem("id_token");
  }

  public isLoggedIn() {
      return moment().isBefore(this.getExpiration());
  }

  isLoggedOut() {
      return !this.isLoggedIn();
  }

  getLogin(): AppUserAuth {
    return this.appUserAuth;
  }
  
  getExpiration() {
      const expiration = this.appUserAuth.expiration;
      return moment(expiration);
  }
}
