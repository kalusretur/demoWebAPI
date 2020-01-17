import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Clients } from '../models/client';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

    constructor(
        private httpClient: HttpClient
    ) { }

    private POST_ENDPOINT: string = "Client";
    private BASE_URL: string = environment.sistemaWebAdmin;
    private REQUEST_URL: string = `${this.BASE_URL}/${this.POST_ENDPOINT}/allClientes`;

    getClients(): Observable<Clients[]> {
        return this.httpClient.get<Clients[]>(`${this.REQUEST_URL}`);
    }
}
