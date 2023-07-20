/*
DO declare components, pipes, directives, and export them.
DO import FormsModule, ReactiveFormsModule and other (3rd-party) modules you need.
DO import the SharedModule into any other Feature Modules.
DO NOT provide app-wide singleton services in your SharedModule. Instead move these to the CoreModule.
DO NOT import the SharedModule into the AppModule.
*/

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation'

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    NgbModule,
    NgBootstrapFormValidationModule.forRoot()
  ],
  exports: [
    FormsModule, 
    ReactiveFormsModule, 
    FontAwesomeModule, 
    NgbModule,
    NgBootstrapFormValidationModule
  ]
})
export class SharedModule { 
  constructor(library: FaIconLibrary) { 
    library.addIconPacks(fas);
  }
}
