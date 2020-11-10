import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';
import { CategoriesCreateComponent } from './categories-create/categories-create.component';
import { CategoriesEditComponent } from './categories-edit/categories-edit.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';


const routes: Routes = [
    {
      path: 'list',
      component: CategoriesListComponent,
      canActivate : [AuthGuard]
    },
    {
        path: 'create',
        component: CategoriesCreateComponent,
        canActivate : [AuthGuard]
    },
    {
        path: ':id/edit',
        component: CategoriesEditComponent,
        canActivate : [AuthGuard]
    },
    {
        path: '',
        redirectTo: '/products/list',
        canActivate : [AuthGuard]
    }
  ];
  
@NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [
      RouterModule
    ]
  })

export class CategoriesRoutingModule {}