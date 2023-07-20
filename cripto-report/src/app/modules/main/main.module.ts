import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module'
import { MainRoutingModule } from './main-routing.module';

import * as LayoutComponents from './components';

@NgModule({
  declarations: [LayoutComponents.components],
  imports: [
    CommonModule,
    MainRoutingModule,
    SharedModule
  ],
  exports: [LayoutComponents.components]
})
export class MainModule { }
