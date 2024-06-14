import {Component, OnInit} from '@angular/core';
import {Client} from "../../Model/client";
import {HttpClient} from "@angular/common/http";
import {ClientService} from "../../Services/client.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  clients: Client[] | undefined;
  dataSource!: any;
  displayedColumns: string[] = ['id', 'name', 'phoneNumber', 'actions'];

  constructor(private http: HttpClient,
              private clientService: ClientService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.getClients()

  }

  public getClients(): void {
    this.clientService.getClient().subscribe({
      next: (clients: Client[]) => {
        this.clients = clients;
        this.dataSource = new MatTableDataSource<Client>(this.clients);
      }
    })
  }

  public deleteClient(id: number): void {
    this.clientService.deleteClient(id).subscribe(() => {
      this.getClients()
    })
  }


}
