import { EditComponent } from './edit/edit.component';
import { CreateComponent } from './create/create.component';
import { ListComponent } from './list/list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';

const routes: Routes = [
    {
      path: 'list',
      component: ListComponent,
      canActivate : [AuthGuard]
    },
    {
        path: 'create',
        component: CreateComponent,
        canActivate : [AuthGuard]
    },
    {
        path: ':id/edit',
        component: EditComponent,
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
  export class ProductsRoutingModule { }