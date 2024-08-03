import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForUpdateDto } from '../../_interfaces/user/userForUpdateDto.model';
import { RegistrationResponseDto } from './../../_interfaces/response/registrationResponseDto.model';
import { UserForRegistrationDto } from './../../_interfaces/user/userForRegistrationDto.model';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public registerUser = (body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute("registration", this.envUrl.urlAddress), body);
  }

  public updateUser = (body: UserForUpdateDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute("updateUser", this.envUrl.urlAddress), body);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/api/accounts/${route}`;
  }
}
