import { LoginService } from './service/login.service';
import { MessageService } from 'primeng/api';
import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { APP_INITIALIZER, NgModule, Optional, SkipSelf } from "@angular/core";
import { TokenInterceptor } from './interceptors/token.interceptor';

export function loginFactory(loginService: LoginService) {
    return () => loginService.checkLogin();
}

@NgModule({
    declarations: [],
    imports: [
        HttpClientModule,
        CommonModule
    ],
    providers: [
        LoginService,
        MessageService,

        //初始執行
        {
            provide: APP_INITIALIZER,
            useFactory: loginFactory,
            deps: [LoginService],
            multi: true
        },

        //HttpRequest攔截
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true
        }
    ]
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {

    }
}
