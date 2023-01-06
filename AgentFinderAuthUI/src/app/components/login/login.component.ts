import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
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
  loginForm!: UntypedFormGroup;
  constructor(
    private fb: UntypedFormBuilder, 
    private auth: AuthService, 
    private router: Router,
    private toast: NgToastService
    ) { }

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
          console.log(res.message);
          this.loginForm.reset();
          alert(res.message);
          this.toast.success({detail:"SUCCESS",summary:res.message,duration: 5000});
          this.router.navigate(['dashboard']);
        }),
        error: (err) => {
          this.toast.error({detail:"ERROR",summary:"Something went wrong!",duration: 5000});
          console.log(err);
        }
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
