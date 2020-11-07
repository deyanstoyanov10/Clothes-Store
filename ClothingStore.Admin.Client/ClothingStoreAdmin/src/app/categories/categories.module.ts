import { RouterModule } from '@angular/router';
import { CategoriesService } from './categories.service';
import { SharedModule } from './../shared/shared.module';
import { CategoriesRoutingModule } from './categories-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { CreateComponent } from './create/create.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    ListComponent, 
    EditComponent, 
    CreateComponent
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
