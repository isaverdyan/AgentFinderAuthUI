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
  selectedMenu!: string;

  constructor(private menuOptionsService: MenuOptionsService, private auth: AuthService,private userStore: UserStoreService) { }

  ngOnInit(): void {
  console.log(' is sidebar');
  var decodedToken = this.auth.getRoleFromToken(); 
  console.log("agent profile - " + decodedToken);
  console.log( JSON.stringify( decodedToken));


    this.menuOptionsService.getAll()
    .subscribe( res => {
      this.menus = res;
      console.log(JSON.stringify(res));
    });

    //this.role = sessionStorage.getItem("userRole");
 

    this.userStore.getRoleFromStore()
        .subscribe(val=>{
           const roleFromToken = this.auth.getRoleFromToken(); 
           this.role = val || roleFromToken;
           console.log(' role = ' + this.role + ' >>> '+roleFromToken );
        });
  }

  selectMenuItem(itemText) {
    console.log(' ggggggggg '+itemText);
    this.selectedMenu = itemText;
  }

}
