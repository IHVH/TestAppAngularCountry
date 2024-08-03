import { Country } from "./country.model";


export interface CountrySelect extends Country {
    disabled: boolean;
    selected: boolean;
}
