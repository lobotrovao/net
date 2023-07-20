import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '@env';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
  
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
        var token = localStorage.getItem("id_token");

        // Best practices to keep http request more safe
        req.headers.set('Cache-Control','no-cache,no-store,max-age=0,must-revalidate'),
        req.headers.set('Pragma','no-cache');
        req.headers.set('content-type','application/json');
        req.headers.set('Expires','-1');

        let newReq = req.clone( { url : `${environment.url}${req.url}` });
        
        if(token) {
            // Add token to request 
            newReq.headers.set('Authorization', 'Bearer ' + token);
        }

        return next.handle(newReq).pipe(
            tap((event: HttpEvent<any>) => {
                    // can make some treatment here
                    return event;
                }),
                catchError((error: HttpErrorResponse) => {
                    console.log(error);
                    console.log(error.status);
                    alert(error.message);
                    return throwError(error);
                })
            );
    }
};