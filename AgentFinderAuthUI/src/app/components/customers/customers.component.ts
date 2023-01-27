import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerApiModel } from 'src/app/models/customer.model';
import * as alertify from 'alertifyjs';
import { SelectionModel } from '@angular/cdk/collections';
import { StringOptionsWithImporter } from 'sass';
import { MatDialog } from '@angular/material/dialog';
import { MessageComponent } from '../message/message.component';
import { AuthService } from 'src/app/services/auth.service';
 

export interface Customer {
  firstname: string;
  lastname: string;
  username: string;
  email: string;  
  id: number;
  userid: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  displayedColumns: string[] = ['select', 'position', 'id', 'firstname', 'lastname', 'username', 'email', 'lastContactDate', 'shortDescription',  'action'];
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement: Customer | null;
  cstdata: any;
  dataSource: any;
  selection = new SelectionModel<Customer>(true, []);
  matrix: [];

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  
  constructor(private auth: AuthService, private customerService: CustomerService, private  dialog:  MatDialog) { }

  ngOnInit(): void {
    this.getAll();
   
    this.customerService.RequiredRefresh.subscribe(r => {
      this.getAll();
    });
  }

  ngAfterViewInit() {

  }

  getAll() {
    var decodedToken = this.auth.decodedToken();
    //console.log(' --------- ' + JSON.stringify(decodedToken));
    
    this.customerService.getCustomersByAgent(decodedToken.name)
      .subscribe( (result) => {
        this.cstdata = result;
        console.log(' --------- ' + JSON.stringify(result));
        this.dataSource = new MatTableDataSource<CustomerApiModel>(this.cstdata);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  FunctionDelete(id: any) {
    alertify.confirm("Remove Employee","Do you want to remove?",()=>{
      this.customerService.Remove(id).subscribe(result => {
        this.getAll();
        alertify.success("Removed successfully.")
      });

    },function(){
    })
    
  }

  Filterchange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }

  onCustomerToggled(customer: Customer) {
    this.selection.toggle(customer);
    
    console.log(this.selection.selected);

  }
    // /** Whether the number of selected elements matches the total number of rows. */
    // isAllSelected() {

    //   const numSelected = this.selection.selected.length;
    //   const numRows = this.dataSource?.data.length;
    //   return numSelected === numRows;
    // }
  
    // /** Selects all rows if they are not all selected; otherwise clear selection. */
    // toggleAllRows() {
     
    //   if (this.isAllSelected()) {
    //     this.selection.clear();
    //     return;
    //   }
  
    //   this.selection.select(...this.dataSource.data);
    // }

    // masterToggle() {
    //   this.isAllSelected()
    //     ? this.selection.clear()
    //     : this.dataSource.data.forEach(row =>
    //         this.dataSource.select(row)
    //       );
    // }
  
    // /** The label for the checkbox on the passed row */
    // checkboxLabel(row?: Customer): string {
    //   if (!row) {
    //     return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    //   }
    //   return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
    // }

    openSendingPopup(){
      const dataSel = this.dataSource.data.filter((item) => item.selected);
      
     var custsel = JSON.stringify(this.selection.selected);
      console.log(' xxxxxxxxxx '+JSON.stringify(this.selection.selected));
      const dialogRef = this.dialog.open(MessageComponent, {
        height: '400px',
        width: '600px',
        data: { messagedata: custsel},
      });
    }

}
