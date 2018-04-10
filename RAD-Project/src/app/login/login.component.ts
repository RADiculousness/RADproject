import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);

  emailM: any;
  passwordM: any;
  
  getEmailErrorMessage() {
    return this.email.hasError('required') ? 'You must enter an email' :
        this.email.hasError('email') ? 'Not a valid email' :
            '';
  }

  getPasswordErrorMessage(){
    return this.password.hasError('required') ? 'You must enter a password' : '';
  }

  login(){
    console.log('not doing that');
    this.router.navigate(['/class-list']);
  }

  constructor(public router: Router) { }

  ngOnInit() {
  }

}
