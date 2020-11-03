import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { RegisterFormModel } from './register.model';
import { Router } from '@angular/router';

function passwordMatch(c : AbstractControl) : ValidationErrors | null{
  return c.value.password === c.value.repeatPassword ? null : { passwordMatch: true};
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm : FormGroup;
  constructor(private fb : FormBuilder, private authService : AuthService, private route : Router) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username : ['', [Validators.required]],
      email : ['', [Validators.required, Validators.email]],
      passwords: this.fb.group({
        password : ['', Validators.required],
        repeatPassword : ['', Validators.required]
      }, { validators : [passwordMatch]})
    })
  }

}
