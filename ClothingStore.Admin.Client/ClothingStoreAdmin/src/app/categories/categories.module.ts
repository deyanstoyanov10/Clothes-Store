import { RouterModule } from '@angular/router';
import { CategoriesService } from './categories.service';
import { SharedModule } from './../shared/shared.module';
import { CategoriesRoutingModule } from './categories-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoriesCreateComponent } from './categories-create/categories-create.component';
import { CategoriesEditComponent } from './categories-edit/categories-edit.component';

@NgModule({
  declarations: [
    CategoriesListComponent,
    CategoriesCreateComponent,
    CategoriesEditComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    HttpClientModule,
    RouterModule,
    CategoriesRoutingModule
  ],
  providers:[
    CategoriesService
  ]
})
export class CategoriesModule { }
