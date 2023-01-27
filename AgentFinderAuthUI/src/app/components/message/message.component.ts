import { HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from  '@angular/material/dialog';
import ValidateForm from 'src/app/helpers/validateform';
import { CustomerApiModel } from 'src/app/models/customer.model';
import { MessageApiModel } from 'src/app/models/message.model';
import { MessageSenderService } from 'src/app/services/message-sender.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnInit {
  chosenUsers = [];
  messageText: string;
  messageForm!: UntypedFormGroup;
  
  constructor(private messageSenderService: MessageSenderService,
              private fb: UntypedFormBuilder, 
               private  dialogRef:  MatDialogRef<MessageComponent>, 
               @Inject(MAT_DIALOG_DATA) public  data:  any) {
    
    // this.data.messagedata.forEach((key, index) => {
    //   console.log(' eeeeeeeeeee ' + Object.entries(key['user']));
    //   this.chosenUsers.push( Object.entries(key['user']));
     
      // Object.keys(key['user']).forEach( (value, ind) => {
      //   console.log(value, ind);
      // })
     // console.log(key, this.data[key], index);
     // console.log(key.shortDescription);
      // Object.entries(key).forEach((ku, indu) => {
      //   console.log(ku, indu);
        
      // });
    //})


  }

  ngOnInit(): void {
    this.messageForm = this.fb.group({
      messageText: ['', Validators.required]     
    });
  }

  public sendMessage() {
    if(this.messageForm.valid) {
      let messageModel = new MessageApiModel();
      messageModel.messageText = this.messageText;     
      messageModel.customers = this.data.messagedata;
      
       this.messageSenderService.sendMessageToCustomer(messageModel);
    }
    else {
        ValidateForm.validateAllFormFields(this.messageForm);
    }
  }

  public  closeMe() {
    this.dialogRef.close();
}

}
