import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from '@angular/core';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatListModule} from '@angular/material/list'
import {
  MatButtonModule, MatDialogModule, MatIconModule, MatInputModule, MatPaginatorModule, MatSortModule,
  MatTableModule, MatToolbarModule,
} from '@angular/material';

@NgModule({
  imports: [MatButtonModule,
       NoopAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatSortModule,
    MatTableModule,
    MatToolbarModule,
    MatPaginatorModule,
    MatTableModule,
MatListModule],

  exports: [MatButtonModule, MatListModule, MatTableModule],
})
export class Material { }