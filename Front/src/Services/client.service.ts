import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Client} from "../Model/client";
import {take} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseURL = 'https://localhost:7156/api/Client';

  constructor(private http: HttpClient) {
  }

  public getClient(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseURL)
  }

  public deleteClient(id: number): Observable<Client> {
    return this.http.delete<Client>(`${this.baseURL}/${id}`)
  }

  public addClient(driver: any): Observable<Client> {
    return this.http.post<Client>(this.baseURL, driver).pipe(take(1))
  }

  public getClientById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.baseURL}/${id}`);
  }
}
