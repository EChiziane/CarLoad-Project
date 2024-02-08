import {Component, OnInit} from '@angular/core';
import {Manager} from "../../Model/manager";
import {HttpClient} from "@angular/common/http";
import {ManagerService} from "../../Services/manager.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";

@Component({
    selector: 'app-manager',
    templateUrl: './manager.component.html',
    styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {
    managers!: Manager[];
    dataSource!: any;
    displayedColumns: string[] = ['id', 'name', 'phoneNumber', 'email', 'actions']

    constructor(private http: HttpClient,
                private managerService: ManagerService,
                private router: Router) {
    }

    ngOnInit(): void {
        this.getManagers();
    }

    public getManagers(): void {
        this.managerService.getManagers().subscribe({
            next: (managers: Manager[]) => {
                this.managers = managers;
                this.dataSource = new MatTableDataSource<Manager>(this.managers);
            }
        })
    }

    public deleteManager(id: number): void {
        this.managerService.deleteManager(id).subscribe(() => {
            this.getManagers();
        })
    }

}
