import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-agent-profile',
  templateUrl: './agent-profile.component.html',
  styleUrls: ['./agent-profile.component.scss']
})
export class AgentProfileComponent implements OnInit {
  public role!:string;
  private hubConnectionBuilder!: HubConnection;
  offers: any[] = [];

  constructor(private auth: AuthService, private userStore: UserStoreService, 
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
