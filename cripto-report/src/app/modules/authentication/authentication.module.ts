import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module'
import * as AuthenticationComponent from './components';
import { AuthenticationRoutingModule } from './authentication-routing.module'

@NgModule({
  declarations: [AuthenticationComponent.components],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    SharedModule,
  ]
})
export class AuthenticationModule { }
