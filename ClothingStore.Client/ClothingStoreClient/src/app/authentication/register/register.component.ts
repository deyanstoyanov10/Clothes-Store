import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';

function passwordMatch(c : AbstractControl) : ValidationErrors | null {
  return c.value.password === c.value.repeatPassword ? null : { passwordMatch: true};
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm : FormGroup;
  constructor(private fb : FormBuilder, private authService : AuthService, private toastr : ToastrService) { 
    this.registerForm = this.fb.group({
      username : ['', [Validators.required]],
      email : ['', [Validators.required, Validators.email]],
      passwords: this.fb.group({
        password : ['', [Validators.required, Validators.minLength(6)]],
        repeatPassword : ['', Validators.required]
      }, { validators : [passwordMatch]})
    });
  }

  ngOnInit(): void {
    
  }

  register() {
    const form = this.registerForm.value;

    const username = form.username;
    const email = form.email;
    const password = form.passwords.password;

    const data = {username, email, password}

    this.authService.register(data).subscribe((data) => {
        if(data == null) {
          this.toastr.success("Congratulations, your account has been successfully created.");
        }
      });
  }

  get username() {
    return this.registerForm.get('username');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('passwords.password');
  }
}
