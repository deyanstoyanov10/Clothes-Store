import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './aside/aside.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { Error404Component } from './error404/error404.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AsideComponent,
     NavComponent, 
     FooterComponent, 
     Error404Component
    ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavComponent,
    AsideComponent,
    FooterComponent,
    Error404Component
  ]
})
export class CoreModule { }
