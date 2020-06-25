import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from 'src/app/Models/user/user';
import { AuthService } from 'src/app/Services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService , private router: Router) { }
  loginModel: UserLoginModel = { Password: null, Username: null }; // new Hero(18, 'Dr IQ', 'Chuck Overstreet');
  submitted = false;
  ngOnInit(): void {
  }

  VerifyUserCredentials() {
    this.auth.IsUserAuthorized(this.loginModel).subscribe(res => console.log(res));
  }

  onSubmit() {

    this.submitted = true;
    console.log('Mehtod called');
    this.auth.AuthenticateUser(this.loginModel)
      .subscribe(res => {
        console.log('Authenticate successfully');
        this.router.navigate(['/home']);
      });
  }

  get diagnostic() { return JSON.stringify(this.loginModel); }
}
 
