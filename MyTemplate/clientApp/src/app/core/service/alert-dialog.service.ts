import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AlertDialogService {

    private defaultDisplay = false;
    private defaultTitle = '提醒訊息';
    private defaultButtonLabel = '確定';
    private defaultAlertMessage = ['系統發生錯誤，請聯絡系統管理員。'];


    /** 是否顯示 */
    display = new BehaviorSubject(this.defaultDisplay);
    /** 標題 */
    title = new BehaviorSubject(this.defaultTitle);
    /** 按鈕文字 */
    buttonLabel = new BehaviorSubject(this.defaultButtonLabel);
    /** 內容文字 */
    alertMessage = new BehaviorSubject<string[]>(this.defaultAlertMessage);

    constructor() { }

    /** 重新設定 */
    reset(): void {
        // 標題
        this.title.next(this.defaultTitle);
        // 按鈕文字
        this.buttonLabel.next(this.defaultButtonLabel);
        // 內容文字
        this.alertMessage.next(this.defaultAlertMessage);
    }

    /** 展現訊息 */
    showAlert(): void {
        this.display.next(true);
    }

    showSystemErrorMessage(): void {
        this.reset();
        this.showAlert();
    }

    showDefaultMessage(): void {
        this.reset();
        this.showAlert();
    }

    /** 展現指定訊息 */
    showAlertMessage(message: string): void {
        this.reset();
        this.showAlertMessage(message);
        this.showAlert();
    }

    /** 展現新增成功訊息 */
    showAddSuccess(): void {
        this.reset();
        this.showAlertMessage('新增成功');
        this.showAlert();
    }

    /** 展現更新成功訊息 */
    showUpdateSuccess() {
        this.reset();
        this.showAlertMessage('更新成功');
        this.showAlert();
    }

    /** 展現刪除成功訊息 */
    showDeleteSuccess() {
        this.reset();
        this.showAlertMessage('刪除成功');
        this.showAlert();
    }

    /** 設定標題 */
    setTitle(data: string) {
        // 標題
        this.title.next(data);
    }

    /** 設定按鈕文字 */
    setButtonLabel(data: string) {
        // 按鈕文字
        this.buttonLabel.next(data);
    }

    /** 設定訊息內容 */
    setAlertMessages(data: string[]) {
        // 內容文字
        this.alertMessage.next(data);
    }

    /** 設定訊息內容(單筆) */
    setAlertMessage(data: string) {

        const message = [data];
        // 內容文字
        this.alertMessage.next(message);
    }

}
