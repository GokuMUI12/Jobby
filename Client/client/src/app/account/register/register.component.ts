import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserForRegistrationDto } from 'src/app/shared/models/user';
import { AuthenticationService } from '../authentication.service';
import { PasswordConfirmationValidatorService } from 'src/app/shared/custom-validators/password-confirmation-validator.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm!: FormGroup;
  public errorMessage: string = '';
  public showError: boolean = false;
  constructor(private authService: AuthenticationService, private passConfValidator: PasswordConfirmationValidatorService) { }
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('', [Validators.required]),
      role: new FormControl('Freelancer', [Validators.required])
    });
  }
  public validateControl = (controlName: string) => {
    return this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName)?.hasError(errorName)
  }
  public registerUser(registerFormValue: any) {
    const formValues = { ...registerFormValue };
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      role: formValues.role
    };
    const confirmControl = this.registerForm?.get('confirm');
    const passwordControl = this.registerForm?.get('password');
    if (confirmControl && passwordControl) {
        confirmControl.setValidators([
        Validators.required,
        this.passConfValidator.validateConfirmPassword(passwordControl),
      ]);
      confirmControl.updateValueAndValidity(); 
    }
  
    this.authService.registerUser(user)
      .subscribe({
        next: (_) => console.log("Successful registration"),
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
        }
      });
  }
}  
