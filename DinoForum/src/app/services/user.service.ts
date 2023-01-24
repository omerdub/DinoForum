import { Injectable } from '@angular/core';
import { User } from '../models/appModels/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor() { }

    private loggedInUserLocalStorageName: string = environment.userDetailsLocalStorageName;

    setLoggedInUser(user: User) {
        localStorage.setItem(this.loggedInUserLocalStorageName, JSON.stringify(user));
    }

    deleteLoggedInUser() {
        localStorage.removeItem(this.loggedInUserLocalStorageName);
    }

    getLoggedInUser() {
        return JSON.parse(localStorage.getItem(this.loggedInUserLocalStorageName));
    }
}