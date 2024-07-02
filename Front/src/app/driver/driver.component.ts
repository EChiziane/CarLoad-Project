import {Component, OnInit, ViewChild} from '@angular/core';
import {Driver} from "../../Model/driver";
import {HttpClient} from "@angular/common/http";
import {DriverService} from "../../Services/driver.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.scss']
})
export class DriverComponent implements OnInit {
  drivers: Driver[] | undefined;
  dataSource!: any;
  displayedColumns: string[] = ['id', 'name', 'birth', 'phoneNumber', 'vehiclePlate', 'vehicleModel','createdBy','createdAt', 'actions'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient,
              private driverService: DriverService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.getDrivers()
  }

  public getDrivers() {
    this.driverService.getDriver().subscribe((drivers: Driver[]) => {
      this.dataSource = new MatTableDataSource<Driver>(drivers);
      this.dataSource.paginator = this.paginator;
    });
  }

  public deleteDriver(id: number): void {
    this.driverService.deleteDriver(id).subscribe(() => {
      this.getDrivers()
    })
  }

}
