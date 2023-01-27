import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICountry } from 'src/app/models/country.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AgentService } from 'src/app/services/agent.service';
import { AgentApiModel } from 'src/app/models/agent.model';
import * as alertify from 'alertifyjs';
import { AuthService } from 'src/app/services/auth.service';
import { SubsribeApiModel } from 'src/app/models/subscribe.model';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.scss']
})
export class AgentsComponent implements OnInit {
  title = "app1";
  displayedColumns: string[] = ['id', 'firstname', 'lastname', 'username', 'email', 'action'];
  agdata: any;
  dataSource: any;
  subscribeModel : SubsribeApiModel;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private auth: AuthService, private http: HttpClient, private agentService: AgentService) { }

   ngOnInit(): void {  
      this.getAll();
   
      this.agentService.RequiredRefresh.subscribe(r => {
        this.getAll();
      });
  }

  getAll() {
    
    this.agentService.getAll()
      .subscribe( (result) => {
        this.agdata = result;

        this.dataSource = new MatTableDataSource<AgentApiModel>(this.agdata);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  SubscribeToAgent(agentUser: string) {
    var decodedToken = this.auth.decodedToken();
    
    this.subscribeModel = new SubsribeApiModel();
    this.subscribeModel.customerUserName = decodedToken.name;
    this.subscribeModel.agentUserName = agentUser;

    var decodedToken = this.auth.decodedToken();
    this.agentService.subscribeToAgent(this.subscribeModel);

    console.log(' =========== ' + decodedToken.name + " ===== agent= "+agentUser);

  }
  // FunctionDelete(id: any) {
  //   alertify.confirm("Remove Employee","Do you want to remove?",()=>{
  //     this.agentService.Remove(id).subscribe(result => {
  //       this.getAll();
  //       alertify.success("Removed successfully.")
  //     });

  //   },function(){

  //   })
    
  // }

  Filterchange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }
  
  ngAfterViewInit() {
    
  }


}
