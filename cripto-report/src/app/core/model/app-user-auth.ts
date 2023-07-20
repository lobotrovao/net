export class AppUserAuth {
    userName: string;
    token: string;
    expiration: Date;

    constructor(){
        this.userName = '';
        this.token = '';
        this.expiration = new Date();
    }
}