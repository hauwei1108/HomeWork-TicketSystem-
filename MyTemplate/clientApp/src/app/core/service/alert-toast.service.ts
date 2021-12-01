import { MessageService } from 'primeng/api';
import { Injectable } from "@angular/core";

export enum SummaryMessage {
    success = '成功訊息',

    info = '提醒訊息',

    danger = '錯誤訊息',

    warn = '警告訊息'
}

@Injectable({
    providedIn: 'root'
})
export class AlertToastService {

    /** 是否為固定的toast */
    sticky = true;
    /** toast存在時間 */
    life = 3000;

    constructor(private messageService: MessageService) { }
}
