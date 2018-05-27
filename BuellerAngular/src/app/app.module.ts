import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { ClassesComponent } from './classes/classes.component';
import { RouterModule } from '@angular/router';
import { BookComponent } from './book/book.component';
import { HttpClientModule } from "@angular/common/http";
@NgModule({
  declarations: [
    AppComponent,
  
    NavigationBarComponent,
    ClassesComponent,
    BookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
