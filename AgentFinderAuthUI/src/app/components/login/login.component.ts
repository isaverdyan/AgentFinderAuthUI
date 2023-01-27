import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from '../../services/auth.service';
import { UserStoreService } from '../../services/user-store.service';

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
    private toast: NgToastService,
    private userStore: UserStoreService
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
     
      this.auth.signIn(this.loginForm.value).subscribe({
        next: (res)=>{          
          this.loginForm.reset();
          this.auth.storeToken(res.accessToken);          
          this.auth.storeRefreshToken(res.refreshToken);

          const tokenPayload = this.auth.decodedToken();
          this.userStore.setFullNameForStore(tokenPayload.name);
          this.userStore.setRoleForStore(tokenPayload.role);
          this.toast.success({detail:"SUCCESS", summary:res.message, duration: 5000});
          if(tokenPayload.role === 'agent'){
            this.router.navigate(['dashboard']);
          }
          else {
            this.router.navigate(['']);
          }
        },
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
