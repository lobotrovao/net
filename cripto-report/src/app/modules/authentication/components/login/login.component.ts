import { Component, OnInit } from '@angular/core';
import { environment } from '@env'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { AuthService } from '@core/services'
import { LoginRequest } from '@core/dto/login-request';
import { LoginResponse } from '@core/dto/login-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  title = environment.appName;
  loginForm = new FormGroup({
    userName: new FormControl(null, Validators.required),
    password: new FormControl(null, Validators.required )
  });

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {

    if (this.loginForm.valid){
      let userLogin = new LoginRequest();
      Object.assign(userLogin, this.loginForm.value);
      this.authService.login(userLogin).subscribe( (data: LoginResponse) => {
          if (data.token !== null){
           this.router.navigate(['content']);
          } else {
            alert("Falha no Login!");
          }
        },
      );
    }
  }
}
