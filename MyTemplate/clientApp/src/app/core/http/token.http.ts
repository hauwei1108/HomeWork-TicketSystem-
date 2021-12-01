import { TokenViewModel } from './../models/token/token-view-model.model';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TokenHttp {
    constructor(private http: HttpClient) { }

    //取得token
    getToken(): Observable<TokenViewModel> {

        const headers: HttpHeaders = new HttpHeaders()
            .append('Content-Type', 'application/json');

        const params = new HttpParams();

        return this.http.get<TokenViewModel>('./api/Token/GetToken', { headers, params })
    }
}
