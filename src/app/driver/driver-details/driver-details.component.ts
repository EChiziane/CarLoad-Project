import {Component, Input, OnInit} from '@angular/core';
import {Driver} from "../../../Model/driver";
import {HttpClient} from "@angular/common/http";
import {DriverService} from "../../../Services/driver.service";
import {ActivatedRoute} from "@angular/router";

@Component({
    selector: 'app-driver-details',
    templateUrl: './driver-details.component.html',
    styleUrls: ['./driver-details.component.scss']
})
export class DriverDetailsComponent implements OnInit {
    @Input() driverId!: number;
    driver!: Driver;

    constructor(private http: HttpClient,
                private driverService: DriverService,
                private route: ActivatedRoute) {
    }

    ngOnInit(): void {

        this.route.params.subscribe(params => {
            this.driverId = +params['id']; // Converte o ID para número
        });
        this.getDriver();
    }

    public getDriver(): void {
        this.driverService.getDriverById(this.driverId).subscribe({
            next: (driver: Driver) => {
                this.driver = driver;
            },
        })
    }

}
