/*
DO import modules that should be instantiated once in your app.
DO place services in the module, but do not provide them.
DO NOT declare components, pipes, directives.
DO NOT import the CoreModule into any modules other than the AppModule.
*/

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpRequestInterceptor } from './interceptor/http-interceptor';
import { NgHttpLoaderComponent, NgHttpLoaderModule } from 'ng-http-loader';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    NgHttpLoaderModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, 
      useClass: HttpRequestInterceptor, 
      multi: true 
    },
  ],
  exports: [NgHttpLoaderModule]
})  
export class CoreModule { }
