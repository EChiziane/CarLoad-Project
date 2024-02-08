import {Component, OnInit} from '@angular/core';
import {Driver} from "../../Model/driver";
import {HttpClient} from "@angular/common/http";
import {DriverService} from "../../Services/driver.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";

@Component({
    selector: 'app-driver',
    templateUrl: './driver.component.html',
    styleUrls: ['./driver.component.scss']
})
export class DriverComponent implements OnInit {
    drivers: Driver[] | undefined;
    dataSource!: any;
    displayedColumns: string[] = ['id', 'name', 'birth', 'phoneNumber', 'vehiclePlate', 'vehicleModel', 'actions'];

    constructor(private http: HttpClient,
                private driverService: DriverService,
                private router: Router) {
    }

    ngOnInit(): void {
        this.getDrivers()
    }

    public getDrivers(): void {
        this.driverService.getDriver().subscribe({
            next: (drivers: Driver[]) => {
                this.drivers = drivers;
                this.dataSource = new MatTableDataSource<Driver>(this.drivers);
            }
        })
    }

    public deleteDriver(id: number): void {
        this.driverService.deleteDriver(id).subscribe(() => {
            this.getDrivers()
        })
    }

}
