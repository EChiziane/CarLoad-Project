import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {DriverService} from "../../../Services/driver.service";
import {Router} from "@angular/router";

@Component({
    selector: 'app-add-driver',
    templateUrl: './add-driver.component.html',
    styleUrls: ['./add-driver.component.scss']
})
export class AddDriverComponent implements OnInit {
    profileForm = new FormGroup({
        name: new FormControl(''),
        birthDate: new FormControl(''),
        phoneNumber: new FormControl(''),
        vehiclePlate: new FormControl(''),
        vehicleModel: new FormControl(''),
    })

    constructor(private http: HttpClient,
                private driverService: DriverService,
                private router: Router) {
    }

    ngOnInit(): void {
    }

    public createDriver(): void {
        this.driverService.addDriver(this.profileForm.value).subscribe(() => {
            this.router.navigate([''])
        })


    }

    public cancelOperation(): void {
        this.router.navigate(['']);
    }


}
