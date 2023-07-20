import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module';
import * as HomeComponent from './components/';
import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [HomeComponent.components],
  imports: [
    CommonModule,
    SharedModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
