import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../models/httpRequests/login.request';
import { RegisterRequest } from '../models/httpRequests/register.request';
import { LoginResponse } from '../models/httpResponses/login.response';
import { RegisterResponse } from '../models/httpResponses/register.response';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private baseUrl = environment.apiBaseUrl;

    constructor(private http: HttpClient) { }

    login(loginRequest: LoginRequest): Observable<LoginResponse> {
        return this.http.post<LoginResponse>(`${this.baseUrl}/user/login`, loginRequest);
    }

    register(registerRequest: RegisterRequest): Observable<RegisterResponse> {
        return this.http.post<RegisterResponse>(`${this.baseUrl}/user/register`, registerRequest);
    }
}