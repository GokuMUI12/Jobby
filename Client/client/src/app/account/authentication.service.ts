import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForRegistrationDto, RegistrationResponseDto, AuthResponseDto, UserForAuthenticationDto } from '../shared/models/user';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  baseUrl = environment.apiUrl;
  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this._isLoggedIn$.asObservable();
  constructor(private http: HttpClient) {
    const token = localStorage.getItem('token')
    this._isLoggedIn$.next(!!token)
  }
  public registerUser = (body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.baseUrl + 'Account/register', body);
  }

  public loginUser = (body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.baseUrl + 'Account/login', body).pipe(
      tap((response: any) => {
        this._isLoggedIn$.next(true)
        localStorage.setItem('token', response.token)
      })
    );
  }
}
