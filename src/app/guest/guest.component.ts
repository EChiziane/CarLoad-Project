import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {GuestService} from "../../Services/guest.service";
import {HttpClient} from "@angular/common/http";
import {Guest} from "../../Model/Guest";
import {MatTableDataSource} from "@angular/material/table";

@Component({
    selector: 'app-guest',
    templateUrl: './guest.component.html',
    styleUrls: ['./guest.component.scss'],

})
export class GuestComponent implements OnInit {
    guests: Guest[] | undefined;
    displayedColumns: string[] = ['id', 'name', 'email', 'confirm', 'actions'];
    dataSource!: any;


    constructor(private http: HttpClient,
                private clientService: GuestService,
                private router: Router) {
    }

    ngOnInit(): void {
        this.getGuests();
    }

    ngAfterViewInit() {

    }

    public getGuests(): void {
        this.clientService.getGuest().subscribe({
            next: (guests: Guest[]) => {
                this.guests = guests;
                this.dataSource = new MatTableDataSource<Guest>(this.guests);
            },
        })
    }

    public deleteGuest(id: number): void {
        this.clientService.deleteGuest(id).subscribe(() => {
            this.getGuests()
        })
    }
}
