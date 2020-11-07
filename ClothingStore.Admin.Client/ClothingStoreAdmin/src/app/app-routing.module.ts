import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Error404Component } from './core/error404/error404.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./categories/categories.module').then(m => m.CategoriesModule)
  },
  {
    path: 'products',
    loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
  },
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule)
  },
  {
    path: '**',
    component : Error404Component
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
