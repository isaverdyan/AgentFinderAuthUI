import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  loginForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onLogin() {
    if(this.loginForm.valid){
      //Send the obj to database
      //console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value).subscribe({
        next: (res=>{
          alert(res.message);
          this.loginForm.reset();
          this.router.navigate(['dashboard']);
        })
      });

      console.log(this.loginForm.value);
    }
    else {
      //throw the error using toaster and required fields

      console.log("form is not valid");

      ValidateForm.validateAllFormFields(this.loginForm);
      alert("your form is invalid");
    }
  }

}
