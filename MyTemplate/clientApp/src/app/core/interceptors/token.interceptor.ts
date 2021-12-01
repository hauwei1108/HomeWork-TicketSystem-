import { Router } from '@angular/router';
import { AlertDialogService, BlockService, LoginService } from 'myTemplateService';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from 'rxjs/operators';
import { IfStmt } from '@angular/compiler';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  token: string;
  loginService: LoginService;
  isLogOuted = false;

  constructor(
    private injector: Injector,
    private alertDialogService: AlertDialogService,
    private router: Router,
    private blockService: BlockService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    // 產生等待畫面
    Promise.resolve(null).then(() => this.blockService.addCount());

    this.loginService = this.injector.get(LoginService);
    this.token = this.loginService.getToken();

    if (this.token != null) {
      // 在每個Request中加入token
      req = req.clone({
        setHeaders: {
          'Authorization': `Bearer ${this.token}`,
          'Cache-Control': 'no-cache'
        }
      });
    }

    return next
      .handle(req)
      .pipe(tap((event: HttpEvent<any>) => { },
        (err: any) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
              if (!this.isLogOuted) {
                this.isLogOuted = true;
                this.alertDialogService.showAlertMessage('尚未登入');
                this.loginService.logout();
              }
            } else if (err.status === 403) {
              this.alertDialogService.showAlertMessage('尚未授權');
              this.router.navigate(['/']);
            } else if (err.status === 400) {
              this.alertDialogService.showSystemErrorMessage
            } else {
              this.alertDialogService.showSystemErrorMessage
            }
            // 關閉等待畫面
            this.blockService.minusCount();
          }
        },
        // 關閉等待畫面
        () => this.blockService.minusCount()
      ));
  }
}
