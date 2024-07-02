import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {CarloadService} from "../../../Services/carload.service";
import {Driver} from "../../../Model/driver";
import {DriverService} from "../../../Services/driver.service";
import {MaterialService} from "../../../Services/material.service";
import {Material} from "../../../Model/material";
import {Manager} from "../../../Model/manager";
import {ManagerService} from "../../../Services/manager.service";
import {SprintService} from "../../../Services/sprint.service";
import {Sprint} from "../../../Model/sprint";


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
  drivers!: Driver[];
  materials!: Material[];
  managers!: Manager[];
  sprinters!: Sprint[];


  profileForm = new FormGroup({
    id: new FormControl(''),
    clientNumber: new FormControl(''),
    destination: new FormControl(''),
    earnings: new FormControl(''),
    fuelExpense: new FormControl(''),
    policeExpense: new FormControl(''),
    driverId: new FormControl(''),
    managerId: new FormControl(''),
    sprintId: new FormControl(''),
    clientName: new FormControl(''),
    materialId: new FormControl(''),
    toll: new FormControl(''),
    purchaseMoney: new FormControl(''),
  })


  constructor(private http: HttpClient,
              private carloadService: CarloadService,
              private sprintService: SprintService,
              private driverService: DriverService,
              private materialService: MaterialService,
              private managerService: ManagerService,
              private router: Router) {
  }

  ngOnInit(): void {

    this.getMaterials();
    this.getDrivers();
    this.getManagers();
    this.getSprinters()


  }

  public createCarLoad(): void {
    console.log(this.profileForm.value)
    this.carloadService.addCarLoad(this.profileForm.value).subscribe(() => {
      this.router.navigate([''])
    })
  }

  public cancelOperation(): void {
    this.router.navigate(['']);
  }

//Client


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

  public getManagers(): void {
    this.managerService.getManagers().subscribe({
      next: (managers: Manager[]) => {
        this.managers = managers;
      }
    })
  }

  public getSprinters(): void {
    this.sprintService.getSprints().subscribe({
      next: (sprinters: Sprint[]) => {
        this.sprinters = sprinters;
      }
    })
  }
}
