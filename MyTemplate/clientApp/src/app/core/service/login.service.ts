import { BehaviorSubject } from 'rxjs';
import { TokenViewModel } from './../models/token/token-view-model.model';
import { TokenHttp } from './../http/token.http';
import { Injector } from "@angular/core";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from 'ngx-cookie-service';
import { lastValueFrom } from 'rxjs';

@Injectable()
export class LoginService {

    private router: Router;

    private tokenKey = "token"
    baseUrl: string;
    loginUser: any;

    //要代理的員編
    isRefreshUserInfo = new BehaviorSubject(true);

    //授權選單資料
    isRefreshMenuItems = new BehaviorSubject(true);

    constructor(
        injector: Injector,
        private tokenHttp: TokenHttp,
        private cookieService: CookieService) {
        setTimeout(() => this.router = injector.get(Router));
    }

    //登入
    login(): Promise<TokenViewModel> {

        return lastValueFrom(this.tokenHttp.getToken())
            .then((data: TokenViewModel) => {
                // status(Failed = -1, NotAuth = 0 ,Success = 1)
                if (data.status === 1) {
                    //儲存value
                    sessionStorage.setItem(this.tokenKey, data.tokenInfo.accessToken);
                }
                return data;
            })
            .catch(this.handleError);
    }

    logout(): void {
        this.cookieService.delete('clientUserName', '/');
        this.cookieService.delete('clientTicket', '/');
        // 清除所有sessionStorage的key
        sessionStorage.clear();
        // 導回初始頁
        window.location.href = './Home/Index'
    }

    //取得token
    getToken() {
        //回傳sessionStorage儲存token
        return sessionStorage.getItem(this.tokenKey);
    }

    checkLogin(): Promise<void> {
        return new Promise<void>(resolve => {
            //檢查是否登入(有無token)
            const isLogin = this.getToken() != null;
            if (!isLogin) {
                //尚未登入 呼叫登入
                this.login().then(
                    result => {
                        // status(Failed = -1, NotAuth = 0 ,Success = 1)
                        if (result.status !== 1) {
                            //不等於1表示沒登入成功 回傳失敗或是沒權限訊息
                            alert(result.message)
                        }
                        resolve();
                    }
                ).catch(err => {
                    resolve();
                })
            } else {
                resolve();
            }
        });
    }

    //刷新使用者訊息
    refreshUserInfo() {
        this.isRefreshUserInfo.next(true);
    }

    //刷新選單
    refreshMenuItems() {
        this.isRefreshMenuItems.next(true);
    }

    //錯誤處理
    private handleError(error: any): Promise<any> {
        alert('系統發生錯誤，請聯絡資訊人員');
        return Promise.reject(error.message || error);
    }
}
