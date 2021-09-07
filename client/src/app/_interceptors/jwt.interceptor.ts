import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  localUrl = environment.apiUrl;

  constructor(private accountService: AccountService) {}

  private isValidUrl(url: string): boolean{
    return url === this.localUrl;
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: User;
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user);
    if(currentUser && this.isValidUrl(request.url.slice(0, this.localUrl.length))){
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.token['result']}`
        }
      })
    }
    
    return next.handle(request);
  }
}
