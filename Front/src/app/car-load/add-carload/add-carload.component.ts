import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {CarloadService} from "../../../Services/carload.service";
import {Client} from "../../../Model/client";
import {ClientService} from "../../../Services/client.service";
import {Driver} from "../../../Model/driver";
import {DriverService} from "../../../Services/driver.service";
import {MaterialService} from "../../../Services/material.service";
import {Material} from "../../../Model/material";
import {Manager} from "../../../Model/manager";
import {ManagerService} from "../../../Services/manager.service";


interface Food {
    value: string;
    viewValue: string;
}

@Component({
    selector: 'app-add-carload',
    templateUrl: './add-carload.component.html',
    styleUrls: ['./add-carload.component.scss']
})
export class AddCarloadComponent implements OnInit {
    clients!: Client[];
    drivers!: Driver[];
    materials!: Material[];
    managers!: Manager[];


    profileForm = new FormGroup({
        id: new FormControl(''),
        destination: new FormControl(''),
        earnings: new FormControl(''),
        fuelExpense: new FormControl(''),
        policeExpense: new FormControl(''),
        driverId: new FormControl(''),
        managerId: new FormControl(''),
        clientId: new FormControl(''),
        materialId: new FormControl(''),
        toll: new FormControl(''),
        purchaseMoney: new FormControl(''),
    })

    constructor(private http: HttpClient,
                private carloadService: CarloadService,
                private clientService: ClientService,
                private driverService: DriverService,
                private materialService: MaterialService,
                private managerService:ManagerService,
                private router: Router) {
    }

    ngOnInit(): void {
        this.getClients();
        this.getMaterials();
      this.getDrivers();
       this.getManagers();
    }

    public createCarLoad(): void {
        this.carloadService.addCarLoad(this.profileForm.value).subscribe(() => {
            this.router.navigate([''])
        })
    }

    public cancelOperation(): void {
        this.router.navigate(['']);
    }

//Client
    public getClients(): void {
        this.clientService.getClient().subscribe({
            next: (clients: Client[]) => {
                this.clients = clients;
            }
        })
    }

    public getDrivers(): void {
        this.driverService.getDriver().subscribe({
            next: (drivers: Driver[]) => {
                this.drivers = drivers;
            }
        })
    }

    public getMaterials(): void {
        this.materialService.getMaterials().subscribe({
            next: (materials: Material[]) => {
                this.materials = materials;
            }
        })
    }

    public getManagers():void{
        this.managerService.getManagers().subscribe({
            next:(managers:Manager[])=>{
                this.managers=managers;
            }
        })
    }
}
