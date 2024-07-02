import {Component, OnInit, ViewChild} from '@angular/core';
import {CarLoad} from "../../Model/car-load";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {CarloadService} from "../../Services/carload.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-car-load',
  templateUrl: './car-load.component.html',
  styleUrls: ['./car-load.component.scss']
})
export class CarLoadComponent implements OnInit {
  carLoads: CarLoad[] | undefined;
  displayedColumns: string[] = [
    'id', 'createdAt', 'materialName', 'sprint', 'earnings', 'expenses', 'destination',
    'clientName', 'clientNumber', 'fuelExpense', 'policeExpense', 'toll', 'purchaseMoney',
    'managerName', 'driverName', 'actions'
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  dataSource = new MatTableDataSource<CarLoad>();

  constructor(private carloadService: CarloadService, private router: Router) {
  }

  ngOnInit(): void {
    this.loadCarLoads();
  }

  loadCarLoads(): void {
    this.carloadService.getCarLoad().subscribe((carloads: CarLoad[]) => {
      this.updateDataSource(carloads);
    });
  }

  loadCarLoadsToday(): void {
    this.carloadService.getCarLoadToday().subscribe((carloads: CarLoad[]) => {
      this.updateDataSource(carloads);
    });
  }

  loadCarLoadsByRange(startDate: Date, endDate: Date): void {
    this.carloadService.getCarLoadRange(startDate, endDate).subscribe((carloads: CarLoad[]) => {
      this.updateDataSource(carloads);
    });
  }

  private updateDataSource(carloads: CarLoad[]): void {
    this.carLoads = carloads;
    this.dataSource.data = this.carLoads;
    this.dataSource.paginator = this.paginator;
    this.paginator._changePageSize(9);
  }
}
