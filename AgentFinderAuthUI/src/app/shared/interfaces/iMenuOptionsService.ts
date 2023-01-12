import { Observable } from "rxjs";
import { IMenuOptionsAPIDTO } from "../dto/menu-options-dto";


export interface IMenuOptionsService {
  getAll():  Observable<IMenuOptionsAPIDTO.IMenuOptionsInfo>;
}
