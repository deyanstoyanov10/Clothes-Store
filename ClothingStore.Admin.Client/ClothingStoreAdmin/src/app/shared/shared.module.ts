import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SharedRoutingModule } from './shared-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptorService } from './token-interceptor.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { ErrorInterceptorService } from './error-interceptor.service';
import { LoaderComponent } from './loader/loader.component';


@NgModule({
  declarations: [
    HomeComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    ToastrModule.forRoot()
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    },
    ToastrService
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    LoaderComponent
  ]
})
export class SharedModule { }
