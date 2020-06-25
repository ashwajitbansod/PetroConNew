import { Component, OnInit } from '@angular/core';
import { RegisterUserModel } from 'src/app/Models/user/Register.User.Model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userRegisterModel: RegisterUserModel = {
    Action: 'i',
    UID_Address: null,
    UID_CIN: null,
    UID_City: null,
    UID_CompanyName: null,
    UID_GSTIN: null,
    UID_MobileNumber: null,
    UID_OilCompany: null,
    UID_PAN: null,
    UID_Pin: null,
    UID_PumpRegNumber: null,
    UID_State: null,
    UID_TIN: null,
    UID_UserId: null,
    UID_UserType: null,
    UID_ValidFrom: null,
    UID_ValidThru: null,
    UID_eMail: null,
    ULA_FirstName: null,
    ULA_LastName: null
  }; // new Hero(18, 'Dr IQ', 'Chuck Overstreet');
  stateList: any[] = [];
  submitted = false;
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
    console.log('Mehtod called');
  }


  GetStates() {
    if (this.stateList.length === 0) {
      this.stateList.push({
        stateId: 1,
        name: 'Uttrakhand'
      });

      this.stateList.push({
        stateId: 2,
        name: 'Maharashtra'
      });
    }
  }
}
