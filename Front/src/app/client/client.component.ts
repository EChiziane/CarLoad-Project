import {Component, OnInit, ViewChild} from '@angular/core';
import {Client} from "../../Model/client";
import {HttpClient} from "@angular/common/http";
import {ClientService} from "../../Services/client.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  clients: Client[] | undefined;
  displayedColumns: string[] = ['id', 'name', 'phoneNumber', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  dataSource = new MatTableDataSource<Client>();

  constructor(private clientService: ClientService, private router: Router) {}

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.clientService.getClient().subscribe((clients: Client[]) => {
      this.updateDataSource(clients);
    });
  }

  deleteClient(id: number): void {
    this.clientService.deleteClient(id).subscribe(() => {
      this.loadClients();
    });
  }

  private updateDataSource(clients: Client[]): void {
    this.clients = clients;
    this.dataSource.data = this.clients;
    this.dataSource.paginator = this.paginator;
    this.paginator._changePageSize(10); // Definindo o tamanho da página como 10 por padrão
  }
}
