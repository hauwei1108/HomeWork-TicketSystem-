import { BehaviorSubject } from 'rxjs';
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class BlockService {

    blockedDocument = new BehaviorSubject<boolean>(false);
    isShow = false;

    //載入數量
    loadingCount = 0;

    constructor() { }

    //增加一筆loading數量
    addCount(): void {
        this.loadingCount++;
        this.refresh();
    }

    //減少一筆loading數量
    minusCount(): void {
        this.loadingCount--;
        this.refresh();
    }

    private refresh(): void {

        if (this.loadingCount > 0) {
            this.isShow = true;
        } else {
            this.isShow = false;
        }

        this.blockedDocument.next(this.isShow);
    }
}
