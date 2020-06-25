
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { StorageService } from './storage/storage.service';
import { StorageKeys } from '../Constants/StorageKeys';
import { finalize, catchError } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private storage: StorageService) { }
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
        // if(req.method === 'POST' || req.method === 'PUT') {
        // }

        const request = req.clone({ headers: new HttpHeaders({ Authorization: 'Bearer ' + this.storage.get(StorageKeys.Token) }) });

        return next.handle(request)
            .pipe(
                finalize(() => console.log('interceptor successfull')),
                catchError((error: HttpErrorResponse) => {
                    console.log(error);
                    return throwError(error);
                }
                ));
    }
}
