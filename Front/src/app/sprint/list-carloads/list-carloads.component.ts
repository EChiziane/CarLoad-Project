import {Component, Input, ViewChild} from '@angular/core';
import {CarLoad} from "../../../Model/car-load";
import {HttpClient} from "@angular/common/http";
import {CarloadService} from "../../../Services/carload.service";
import {ActivatedRoute, Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-list-carloads',
  templateUrl: './list-carloads.component.html',
  styleUrls: ['./list-carloads.component.scss']
})
export class ListCarloadsComponent {
  @Input() sprintId!: number;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  carLoads: CarLoad[] | undefined;
  displayedColumns: string[] = ['id',
    'createdAt',
    'materialName',
    'sprint',
    'earnings',
    'expenses',
    'destination',
    'clientName',
    'clientNumber',
    'fuelExpense',
    'policeExpense',
    'toll',
    'purchaseMoney',
    'managerName',
    'driverName',
    'actions'];


  dataSource!: any;

  constructor(private http: HttpClient,
              private carLoadService: CarloadService,
              private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.sprintId = +params['id'];
    });

    this.getCarLoadBySprint(this.sprintId);
  }


  public getCarLoad(sprintId: number): void {
    this.carLoadService.getCarLoadBySprint(sprintId).subscribe({
      next: (carloads: CarLoad[]) => {
        this.carLoads = carloads;
        this.dataSource = new MatTableDataSource<CarLoad>(this.carLoads);
      }
    })
  }

  getCarLoadBySprint(sprintId: number) {
    this.carLoadService.getCarLoadBySprint(sprintId).subscribe((carloads: CarLoad[]) => {
      this.dataSource = new MatTableDataSource<CarLoad>(carloads);
      this.dataSource.paginator = this.paginator;
      this.dataSource.paginator._changePageSize(10);
    });
  }

}
