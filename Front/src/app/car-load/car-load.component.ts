import {Component, OnInit} from '@angular/core';
import {CarLoad} from "../../Model/car-load";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {CarloadService} from "../../Services/carload.service";
import {MatTableDataSource} from "@angular/material/table";

@Component({
    selector: 'app-car-load',
    templateUrl: './car-load.component.html',
    styleUrls: ['./car-load.component.scss']
})
export class CarLoadComponent implements OnInit {
    carLoads: CarLoad[] | undefined;
    displayedColumns: string[] = ['id',
        'createdAt',
        'materialName',
        'earnings',
        'expenses',
        'destination',
        'clientName',
        'fuelExpense',
        'policeExpense',
        'toll',
        'purchaseMoney',
        'managerName',
        'driverName',
        'actions'];


    dataSource!: any;

    constructor(private http: HttpClient,
                private carloadService: CarloadService,
                private router: Router) {
    }

    ngOnInit(): void {

        this.getCarLoad()

    }

    public getCarLoad(): void {
        this.carloadService.getCarLoad().subscribe({
            next: (carloads: CarLoad[]) => {
                this.carLoads = carloads;
                this.dataSource = new MatTableDataSource<CarLoad>(this.carLoads);
            }
        })
    }

}
