import { IAuthenticationConfiguration } from "./shared/interfaces/iauthentication-configuration";
import { IApplicationConfiguration } from "./shared/interfaces/iapplication-configuration";
import { HttpClient } from "@angular/common/http";
import { environment } from "../environments/environment";
//import { config } from "process";
import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class AppConfig implements IAuthenticationConfiguration {
    public originUrl: string = "";
    public agentFinderApi = "https://localhost:7216/";
    public loginPage: string = "";
    public logoutPage: string = "";
    public homePage: string = "";
    public reviewsApiUrl: string = "";
   
    public authSettings: IAuthenticationConfiguration = {
        authority: "",
        redirectUri: "",
        clientId: "",
        responseType: "",
        scope: ""
    };
    public onConfigLoaded: Subject<void> = new Subject();
    public backOfficeApiUrl: string;
    public userManagementApiUrl: string;
    public webAppUrl: string;

    constructor(
        private readonly http: HttpClient
    ) {
    }
    authority: string;
    redirectUri: string;
    clientId: string;
    responseType: string;
    scope: string;
    postLogoutRedirectUri: string;
   

    private parse(configuration: IApplicationConfiguration) {
        this.originUrl = configuration.originUrl ? configuration.originUrl : window.location.protocol + "//" + window.location.host;
        this.agentFinderApi = configuration.agentFinderApi;
        this.reviewsApiUrl = configuration.reviewsApiUrl;

        this.loginPage = configuration.loginPage;
        this.logoutPage = configuration.logoutPage;
        this.homePage = configuration.homePage;
    }

    public load(): Promise<void> {
        return new Promise<void>((resolve, reject) => {
            this.http.get<IApplicationConfiguration>(environment.configurationFile).subscribe(response => {
                this.parse(response);
                this.onConfigLoaded.next();
                this.onConfigLoaded.complete();
                resolve();
            }, (response: any) => {
                reject(`Could not load file '${environment.configurationFile}': ${JSON.stringify(response)}`);
            });
        });
    }
}