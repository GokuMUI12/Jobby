import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserForAuthenticationDto, AuthResponseDto } from 'src/app/shared/models/user';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl: string = '';
  loginForm!: FormGroup;
  errorMessage: string = '';
  showError: boolean = false;
  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }
  
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  validateControl = (controlName: string) => {
     return this.loginForm?.get(controlName)?.invalid && this.loginForm?.get(controlName)?.touched
    
  }
  hasError = (controlName: string, errorName: string) => {
     return this.loginForm?.get(controlName)?.hasError(errorName)
  }
  
  public loginUser = (loginFormValue : any) => {
    const login = {... loginFormValue };
    const userForAuth: UserForAuthenticationDto = {
      email: login.username,
      password: login.password
    };
    this.authService.loginUser(userForAuth)
    .subscribe({
      next: (res:AuthResponseDto) => {
      //  localStorage.setItem("token", res.token);
       this.router.navigate([this.returnUrl]);
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
    }})
  }
}
