import { IAuthenticationConfiguration } from "./iauthentication-configuration";
import { Observable } from "rxjs";


export interface IApplicationConfiguration {
    originUrl: string;
    agentFinderApi: string;
    loginPage: string;
    logoutPage: string;
    homePage: string;
    reviewsApiUrl: string;
    backOfficeApiUrl: string;
    userManagementApiUrl: string;
    webAppUrl: string;
    authSettings: IAuthenticationConfiguration
    angularProdMode: boolean;
    onConfigLoaded: Observable<void>;
}


