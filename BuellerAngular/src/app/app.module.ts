import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// import {Material  } from "./material.module";
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { ClassesComponent } from './classes/classes.component';
import { RouterModule } from '@angular/router';
import { BookComponent } from './book/book.component';
import { HttpClientModule } from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BookByClassComponent } from './book-by-class/book-by-class.component';
@NgModule({
  declarations: [
    AppComponent,
    
  
    NavigationBarComponent,
    ClassesComponent,
    BookComponent,
    BookByClassComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    // Material,
    RouterModule
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
