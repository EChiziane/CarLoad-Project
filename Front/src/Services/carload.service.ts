import {Injectable} from '@angular/core';
import {CarLoad} from "../Model/car-load";
import {take} from "rxjs/operators";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class CarloadService {
    baseURL = 'https://localhost:7156/api/CarLoad';

    constructor(private http: HttpClient) {
    }

    public getCarLoad(): Observable<CarLoad[]> {
        return this.http.get<CarLoad[]>(this.baseURL)
    }

    public deleteCarLoad(id: number): Observable<CarLoad> {
        return this.http.delete<CarLoad>(`${this.baseURL}/${id}`)
    }

    public getCarLoadById(id: number): Observable<CarLoad> {
        return this.http.get<CarLoad>(`${this.baseURL}/${id}`);
    }

    public addCarLoad(driver: any): Observable<any> {
        return this.http.post<any>(this.baseURL, driver).pipe(take(1))
    }

}
