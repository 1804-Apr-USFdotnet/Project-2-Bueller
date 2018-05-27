import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes ,  RouterModule } from "@angular/router";
import { ClassesComponent } from './classes/classes.component';
import { BookComponent } from './book/book.component';


const appRoutes: Routes = [
  // { path: "classes", component: ClassesComponent },
  { path: "book", component: BookComponent }
]
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: []
})
export class AppRoutingModule { }
