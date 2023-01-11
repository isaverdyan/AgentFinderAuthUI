import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public fullName:  string = "";
  public role!:string;

  constructor(private auth: AuthService, private userStore: UserStoreService) { }

  ngOnInit(): void {
    this.userStore.getFullNameFromStore()
      .subscribe(val=>{
        const fullNameFromToken = this.auth.getFullNameFromToken();
        this.fullName = val || fullNameFromToken;        
      });

      this.userStore.getRoleFromStore()
        .subscribe(val=>{
           const roleFromToken = this.auth.getRoleFromToken(); 
           this.role = val || roleFromToken;
        });
  }

  logout() {
    this.auth.signOut();
  }
  
}
