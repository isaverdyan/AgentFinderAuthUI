import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-offer-box',
  templateUrl: './offer-box.component.html',
  styleUrls: ['./offer-box.component.scss']
})
export class OfferBoxComponent implements OnInit {
  private hubConnectionBuilder!: HubConnection;
    offers: any[] = [];
    public role!:string;

  constructor(private auth: AuthService, 
    private userStore: UserStoreService, 
    private router: Router, 
    private toast: NgToastService) { }

  ngOnInit(): void {
    this.userStore.getRoleFromStore()
    .subscribe(val=>{
       const roleFromToken = this.auth.getRoleFromToken(); 
       this.role = val || roleFromToken;
    });

    this.hubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7216/offers').configureLogging(LogLevel.Information).build();
        this.hubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
        this.hubConnectionBuilder.on('SendOffersToUser', (result: any) => {
            this.offers.push(result);            
        });
  }

}
