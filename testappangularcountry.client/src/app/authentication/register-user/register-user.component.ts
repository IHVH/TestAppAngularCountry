import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserForRegistrationDto } from './../../_interfaces/user/userForRegistrationDto.model';
import { AuthenticationService } from './../../shared/services/authentication.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PasswordConfirmationValidatorService } from '../../shared/custom-validators/password-confirmation-validator.service';
import { Country } from '../../_interfaces/country/country.model';
import { UserForUpdateDto } from '../../_interfaces/user/userForUpdateDto.model';
import { CountriesService } from '../../shared/services/countries.service';
import { Province } from '../../_interfaces/country/province.model';
import { ProvinceSelect } from "../../_interfaces/country/provinceSelect.model";
import { CountrySelect } from '../../_interfaces/country/countrySelect.model';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent implements OnInit {
  private readonly passMinLength: number = 2;
  private readonly passMaxLength: number = 50;
  private readonly passPattern: string = "^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$";

  registerForm!: FormGroup;
  updateForm!: FormGroup;

  countryPlaceholder: CountrySelect = { id: 0, name: "Select country", selected: true, disabled: true };
  countries: CountrySelect[] = <CountrySelect[]>[this.countryPlaceholder];
  provincePlaceholder: ProvinceSelect = { id: 0, name: "Please select country first", selected: true, disabled: true };
  provinces: ProvinceSelect[] = <ProvinceSelect[]>[this.provincePlaceholder];
  
  errorMessage: string = '';
  showError: boolean = false;
  step1IsVisible: boolean = true;
  step2IsVisible: boolean = false;

  constructor(private authService: AuthenticationService,
    private countriesService: CountriesService,
    private passConfValidator: PasswordConfirmationValidatorService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required,
        Validators.minLength(this.passMinLength), Validators.maxLength(this.passMaxLength), Validators.pattern(this.passPattern)]),
      confirm: new FormControl(''),
      agree: new FormControl('', [Validators.requiredTrue])
    });
    this.registerForm.get('confirm')?.setValidators([Validators.required,
      this.passConfValidator.validateConfirmPassword(this.registerForm.get('password')!)]);

    this.updateForm = new FormGroup({
      country: new FormControl('', [Validators.required]),
      province: new FormControl('', [Validators.required])
    });
    
    this.countriesService.getCountries().subscribe({
      next: (countries: Country[]) => {
        this.countries = countries as CountrySelect[];
        this.countries.unshift(this.countryPlaceholder);
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        this.errorMessage = err.message;
        this.showError = true;
      }
    });

    
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

  public validateUpdateControl = (controlName: string) => {
    if (this.updateForm.get(controlName)?.invalid && this.updateForm.get(controlName)?.touched)
      return true;
    return false;
  }
  public updateFormHasError = (controlName: string, errorName: string) => {
    if (this.updateForm.get(controlName)?.hasError(errorName))
      return true;
    return false;
  }

  public registerUser = (registerFormValue: any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      agree: formValues.agree
    };
    this.authService.registerUser(user).subscribe({
      next: (_) => {
        console.log("Successful registration")
        this.step1IsVisible = false;
        this.step2IsVisible = true;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        this.step1IsVisible = true;
        this.step2IsVisible = false;
        this.errorMessage = err.message;
        this.showError = true;
      }
    });
  }

  public onCountryChange() {
    let id = this.updateForm.value.country.id;
    this.countriesService.getProvinces(id).subscribe({
      next: (provinces: Province[]) => {
        this.provinces = provinces as ProvinceSelect[];
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        this.errorMessage = err.message;
        this.showError = true;
      }
    });
  }

  public onProvinceChange() {
    console.log("on province change");
    console.log(this.updateForm.value);
  }

  public updateUser = (formValue: any) => {
    this.showError = false;
    const updateFormValues = { ...formValue };
    const userUpdate: UserForUpdateDto = {
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
      confirmPassword: this.registerForm.value.confirm,
      agree: this.registerForm.value.agree,
      countryId: updateFormValues.country.id,
      provinceId: updateFormValues.province.id
    };

    this.authService.updateUser(userUpdate).subscribe({
      next: (_) => {
        alert("Successful!");
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        this.errorMessage = err.message;
        this.showError = true;
      }
    });
  }

}
