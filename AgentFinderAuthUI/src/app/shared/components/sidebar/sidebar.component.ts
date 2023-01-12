import { Component, OnInit } from '@angular/core';
import { MenuOptionsService } from 'src/app/services/menu-options.service';
import { Observable } from 'rxjs';
import { UserStoreService } from 'src/app/services/user-store.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  public menus:any = [];
  public role!:string;
  
  constructor(private menuOptionsService: MenuOptionsService, private auth: AuthService,private userStore: UserStoreService) { }

  ngOnInit(): void {
    //debugger;
    this.menuOptionsService.getAll()
    .subscribe( res => {
      this.menus = res;
      console.log(JSON.stringify(res));
    });

    this.userStore.getRoleFromStore()
        .subscribe(val=>{
           const roleFromToken = this.auth.getRoleFromToken(); 
           this.role = val || roleFromToken;
        });
  }

}
