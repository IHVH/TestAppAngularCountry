import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserForRegistrationDto } from './../../_interfaces/user/userForRegistrationDto.model';
import { AuthenticationService } from './../../shared/services/authentication.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent implements OnInit {
  registerForm!: FormGroup;
  constructor(private authService: AuthenticationService) { }
  ngOnInit(): void {
     this.registerForm = new FormGroup({
       email: new FormControl('', [Validators.required, Validators.email]),
       password: new FormControl('', [Validators.required,
       Validators.minLength(2), Validators.maxLength(50), Validators.pattern("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")]),
       confirm: new FormControl(''),
       agree: new FormControl('', [Validators.requiredTrue])
     })
  }
  public validateControl = (controlName: string) => {
    if (this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched)
      return true;
    return false;
  }
  public hasError = (controlName: string, errorName: string) => {
    if (this.registerForm.get(controlName)?.hasError(errorName))
      return true;
    return false;
  }
  public registerUser = (registerFormValue: any) => {
    const formValues = { ...registerFormValue };
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      agree: formValues.agree
    };
    this.authService.registerUser("api/accounts/registration", user)
      .subscribe({
        next: (_) => console.log("Successful registration"),
        error: (err: HttpErrorResponse) => console.log(err.error.errors)
      })
  }
}
