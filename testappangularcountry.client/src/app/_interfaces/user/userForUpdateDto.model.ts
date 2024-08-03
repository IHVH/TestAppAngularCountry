import { UserForRegistrationDto } from "./userForRegistrationDto.model";

export interface UserForUpdateDto extends UserForRegistrationDto {
  countryId: number;
  provinceId: number;
}
