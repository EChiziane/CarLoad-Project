import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Driver} from "../Model/driver";
import {take} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class DriverService {
    baseURL = 'https://localhost:7156/api/Driver';

    constructor(private http: HttpClient) {
    }

    public getDriver(): Observable<Driver[]> {
        return this.http.get<Driver[]>(this.baseURL)
    }

    public deleteDriver(id: number): Observable<Driver> {
        return this.http.delete<Driver>(`${this.baseURL}/${id}`)
    }

    public getDriverById(id: number): Observable<Driver> {
        return this.http.get<Driver>(`${this.baseURL}/${id}`);
    }

    public addDriver(driver: Driver): Observable<Driver> {
        return this.http.post<Driver>(this.baseURL, driver).pipe(take(1))
    }

    public getDriveById(id: number): Observable<Driver> {
        return this.http.get<Driver>(`${this.baseURL}/${id}`);
    }

}
