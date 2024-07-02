import {Component, OnInit, ViewChild} from "@angular/core";
import {Sprint} from "../../Model/sprint";
import {HttpClient} from "@angular/common/http";
import {SprintService} from "../../Services/sprint.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";


@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html',
  styleUrls: ['./sprint.component.scss']
})
export class SprintComponent implements OnInit {

  sprints: Sprint[] | undefined;
  dataSource!: any;
  displayedColumns: string[] = ['id', 'name', 'status', 'contCarLoad', 'driverName', 'createdBy', 'createdAt', 'actions'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private http: HttpClient,
    private sprintService: SprintService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.getSprints();
  }


  getSprints() {
    this.sprintService.getSprints().subscribe((sprints: Sprint[]) => {
      this.dataSource = new MatTableDataSource<Sprint>(sprints);
      this.dataSource.paginator = this.paginator;
    });
  }

  public deleteSprint(id: number): void {
    this.sprintService.deleteSprint(id).subscribe(() => {
      this.getSprints();
    });
  }

}
