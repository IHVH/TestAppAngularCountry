import { TestBed } from "@angular/core/testing";
import { PasswordConfirmationValidatorService } from "./password-confirmation-validator.service";
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";


describe('PasswordConfirmationValidatorService', () => {
  let service: PasswordConfirmationValidatorService;
  
  beforeEach(() => {
    service = new PasswordConfirmationValidatorService();
  });

  it('#validateConfirmPassword should return null when password and confirm are identical', () => {
    let registerForm = new FormGroup({
      password: new FormControl('t1', [Validators.required]),
      confirm: new FormControl('t1')
    });

    registerForm.markAllAsTouched();
    let fn = service.validateConfirmPassword(registerForm.get('password')!);
    let result = fn.call(registerForm.get('password')!, registerForm.get('confirm')!);
    expect(result).toBeNull();
  });

  it("#validateConfirmPassword should return ValidationErrors when password and confirm aren't identical  ", () => {
    let registerForm = new FormGroup({
      password: new FormControl('t1', [Validators.required]),
      confirm: new FormControl('t2')
    });

    registerForm.markAllAsTouched();
    let fn = service.validateConfirmPassword(registerForm.get('password')!);
    let result = fn.call(registerForm.get('password')!, registerForm.get('confirm')!);
    expect(result).toEqual(<ValidationErrors>{ mustMatch: true });
  });

  it('#validateConfirmPassword should return null when confirm is empty ', () => {
    let registerForm = new FormGroup({
      password: new FormControl('t1', [Validators.required]),
      confirm: new FormControl('')
    });

    registerForm.get('password')?.markAsTouched();
    let fn = service.validateConfirmPassword(registerForm.get('password')!);
    let result = fn.call(registerForm.get('password')!, registerForm.get('confirm')!);
    expect(result).toBeNull();
  });

});
