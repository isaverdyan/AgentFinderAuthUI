import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-contact-inbox',
  templateUrl: './contact-inbox.component.html',
  styleUrls: ['./contact-inbox.component.scss']
})
export class ContactInboxComponent implements OnInit {
  public role!:string;
  constructor(
    private auth: AuthService, 
    private userStore: UserStoreService, 
    private router: Router, 
    private toast: NgToastService) { }

  ngOnInit(): void {
    this.userStore.getRoleFromStore()
    .subscribe(val=>{
       const roleFromToken = this.auth.getRoleFromToken(); 
       this.role = val || roleFromToken;
    });
  }

}
