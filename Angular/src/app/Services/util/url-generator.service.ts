import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UrlGeneratorService {
  webHostName: string;
  constructor() {
    this.webHostName = window.location.hostname;
  }

  getBaseUrl(): string {
    return this.GetApiHostName();
  }

  GetApiHostName(): string {
    let url = '';

    if (this.webHostName === 'localhost') {
      url = environment.dev.apiUrl;
    }
    return url;
  }
  GetAuthHostName(): string {
    let url = '';

    if (this.webHostName === 'localhost') {
      url = environment.dev.authUrl;
    }
    return url;
  }
}
