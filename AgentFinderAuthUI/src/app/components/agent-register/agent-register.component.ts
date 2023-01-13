import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormControl, UntypedFormGroup, Validators, FormGroup, UntypedFormControl } from '@angular/forms';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agent-register',
  templateUrl: './agent-register.component.html',
  styleUrls: ['./agent-register.component.scss']
})
export class AgentRegisterComponent implements OnInit {
  signUpForm!: UntypedFormGroup;
  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash"
  
  constructor(
    private fb: UntypedFormBuilder, 
    private auth: AuthService, 
    private router: Router, 
    private toast: NgToastService) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required]
    });
  }

  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onSignUp() {

    if(this.signUpForm.valid) {    
      sessionStorage.setItem("userRole", "agent");

     
       var fbGroup = this.signUpForm.value;
       fbGroup.role = "Agent";
       this.auth.signUp(fbGroup).subscribe({
          next: (res => {          
            this.signUpForm.reset();
          
            this.router.navigate(['login']);
          }),
          error:( err => {
            this.toast.error({detail:"ERROR", summary:"Something went wrong!", duration: 5000});
          })
       });
    }
    else {
        ValidateForm.validateAllFormFields(this.signUpForm);
    }
  }

}
