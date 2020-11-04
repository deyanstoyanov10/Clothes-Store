import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;
  constructor(private fb : FormBuilder, private authService : AuthService, private router : Router, private toastr : ToastrService) { 
    this.loginForm = this.fb.group({
      username : ['', [Validators.required]],
      password : ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    localStorage.removeItem('token');
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe((data) => {
      console.log(data.token);
      this.authService.saveToken(data.token);
      this.toastr.success("Successfully signed in!");
      this.router.navigate(['/home']).then(() => {
        window.location.reload();
      });
    })
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
