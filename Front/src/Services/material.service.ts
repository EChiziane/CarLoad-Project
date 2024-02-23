import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Material} from "../Model/material";
import {take} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class MaterialService {
    baseURL = 'https://localhost:7156/api/Material';

    constructor(private http: HttpClient) {
    }

    public getMaterials(): Observable<Material[]> {
        return this.http.get<Material[]>(this.baseURL);
    }

    public deleteMaterials(id: number): Observable<Material> {
        return this.http.delete<Material>(`${this.baseURL}/${id}`);
    }

    public getMaterialById(id: number): Observable<Material> {
        return this.http.get<Material>(`${this.baseURL}/${id}`);
    }

    public addMaterial(material: any): Observable<any> {
        return this.http.post<any>(this.baseURL, material).pipe(take(1));
    }

}
