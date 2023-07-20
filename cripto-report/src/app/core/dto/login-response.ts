export class LoginResponse {
    expiration: Date;
    token: string;

    constructor(){
        this.expiration = new Date();
        this.token = '';
    }
}