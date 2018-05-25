import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes ,  RouterModule } from "@angular/router";
import { ClassesComponent } from './classes/classes.component';


const appRoutes: Routes = [
  { path: "classes", component: ClassesComponent }
]
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: []
})
export class AppRoutingModule { }
