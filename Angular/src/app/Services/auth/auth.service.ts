import { Injectable } from '@angular/core';
import { UserLoginModel, User } from 'src/app/Models/user/user';
import { HttpClient, HttpParams, HttpBackend, HttpClientModule } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { UrlGeneratorService } from '../util/url-generator.service';
import { APIUrls } from 'src/app/Constants/apiUrls.constant';
import { tap } from 'rxjs/operators';
import { StorageService } from '../storage/storage.service';
import { StorageKeys } from 'src/app/Constants/StorageKeys';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  http: HttpClient;
  constructor(
    private router: Router,
    httpHead: HttpBackend,
    private utility: UrlGeneratorService,
    private storage: StorageService) {
    this.http = new HttpClient(httpHead);
  }

  AuthenticateUser(objUser: UserLoginModel) {

    const requestHeaders = { withCredentials: false };
    // return this.http.get<any>(this.utility.GetAuthHostName() + APIUrls.GetTest , requestHeaders);
    return this.http.post<User>(this.utility.GetAuthHostName() + APIUrls.authenticateUser, objUser).pipe(
      tap((data) => {
        this.handleAuth(data);
      }, (e) => {
        console.log(e); this.storage.set(StorageKeys.Token, null);
      }
      ));
  }
  handleAuth(data: User) {
    this.storage.set(StorageKeys.Token, data.token);
    this.storage.set(StorageKeys.UserName, data.username);
    this.storage.set(StorageKeys.UserId, data.userId);
    if (data.token) {
      this.loggedIn.next(true);
    }
  }

  IsUserAuthorized(obj: UserLoginModel): Observable<any> {
    const requestHeaders = obj !== null ?
      {
        withCredentials: true,
        params: new HttpParams()
          .set('UserName', obj.Username)
          .set('Password', obj.Password)
      } : { withCredentials: true };
    return this.http.get<any>(this.utility.GetAuthHostName() + APIUrls.isUserAuthorised, requestHeaders);
  }

  get isLoggedIn() {
    if (this.storage.get(StorageKeys.Token)) {
      this.loggedIn.next(true);
    } else {
      this.loggedIn.next(false);
    }
    return this.loggedIn.asObservable();
  }

  logout() {
    this.loggedIn.next(false);
    this.storage.Clear();
    this.router.navigate(['/login']);
  }
}
