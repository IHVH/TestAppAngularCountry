import { Province } from "./province.model";

export interface ProvinceSelect extends Province {
    disabled: boolean;
    selected: boolean;
}
