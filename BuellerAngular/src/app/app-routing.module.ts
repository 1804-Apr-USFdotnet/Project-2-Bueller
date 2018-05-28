import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes ,  RouterModule } from "@angular/router";
import { ClassesComponent } from './classes/classes.component';
import { BookComponent } from './book/book.component';
import { BookByClassComponent } from "./book-by-class/book-by-class.component";


const appRoutes: Routes = [
  // { path: "classes", component: ClassesComponent },
  { path: "book", component: BookComponent },
  { path: "bookByClass/:classId", component: BookByClassComponent }
]
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: []
})
export class AppRoutingModule { }
