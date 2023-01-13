import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  signUpForm!: UntypedFormGroup;
  constructor(
    private fb: UntypedFormBuilder, 
    private auth: AuthService, 
    private router: Router, 
    private toast: NgToastService) { }

  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  ngOnInit() {
    this.signUpForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required]
    });
  }
  
  onSignUp() {
   
    if(this.signUpForm.valid) {
      sessionStorage.setItem("userRole", "customer");
      this.auth.signUp(this.signUpForm.value).subscribe({
        next: (res=>{
          //alert(res.message);
          this.signUpForm.reset();
         
          this.router.navigate(['login']);
        }),
        error:(err=>{
          this.toast.error({detail:"ERROR",summary:"Something went wrong!", duration: 5000});
        })
      });
    }
    else {
        ValidateForm.validateAllFormFields(this.signUpForm);
    }
  }
 

}
