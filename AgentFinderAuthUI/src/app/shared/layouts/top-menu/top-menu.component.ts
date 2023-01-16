import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UserStoreService } from '../../../services/user-store.service';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.scss']
})
export class TopMenuComponent implements OnInit {
  public role!:string;
  constructor(private auth: AuthService, private userStore: UserStoreService) { }

  ngOnInit(): void {
    this.userStore.getRoleFromStore()
    .subscribe(val=>{
       const roleFromToken = this.auth.getRoleFromToken(); 
       this.role = val || roleFromToken;

       console.log(' cccccccccccc '+this.role);
    });
  }



}
