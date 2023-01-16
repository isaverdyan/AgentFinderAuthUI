import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Component({
  selector: 'app-agent-profile',
  templateUrl: './agent-profile.component.html',
  styleUrls: ['./agent-profile.component.scss']
})
export class AgentProfileComponent implements OnInit {
  role: any;
  private hubConnectionBuilder!: HubConnection;
  offers: any[] = [];

  constructor(private auth: AuthService, 
    private router: Router, 
    private toast: NgToastService) { }

    ngOnInit(): void {
      this.hubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7216/offers').configureLogging(LogLevel.Information).build();
      this.hubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
      this.hubConnectionBuilder.on('SendOffersToUser', (result: any) => {
          this.offers.push(result);
      });
  }

}
