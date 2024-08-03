import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { Country } from '../../_interfaces/country/country.model';
import { Province } from '../../_interfaces/country/province.model';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }


  public getCountries = (): Observable<Country[]> => {
    return this.http.get(this.createCompleteRoute("list", this.envUrl.urlAddress)).pipe(map((data: any) => {
      return data.map(function (country: any): Country {
        return <Country>{ id: country.id, name: country.name };
      });
    }));
  }

  public getProvinces = (countryId: number): Observable<Province[]> => {
    return this.http.get(this.createCompleteRoute("ProvincesList", this.envUrl.urlAddress), { params: { countryId: countryId } })
      .pipe(map((data: any) => {
        return data.map(function (province: any): Province {
          return <Province>{ id: province.id, name: province.name };
        });
      }));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/api/countries/${route}`;
  }
}
