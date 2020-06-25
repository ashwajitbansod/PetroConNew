import { Injectable } from '@angular/core';
import { StorageKeys } from '../../Constants/StorageKeys';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }
  set(key: string, value: any): void {
    localStorage.setItem(key, value);
  }

  get(key: string): string {
    return localStorage.getItem(key);
  }

  getStorageData(): any {
    const it = this.get(StorageKeys.Token);
    return it == null ? null : JSON.parse(atob(it.split('.')[1]));
  }

  Clear() {
    localStorage.clear();
  }
}
