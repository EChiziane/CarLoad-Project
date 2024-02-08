import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {ClientService} from "../../../Services/client.service";
import {Client} from "../../../Model/client";

@Component({
    selector: 'app-client-details',
    templateUrl: './client-details.component.html',
    styleUrls: ['./client-details.component.scss']
})
export class ClientDetailsComponent implements OnInit {
    @Input() clientId!: number;
    client!: Client;
    profileForm = new FormGroup({
        name: new FormControl(''),
        phoneNumber: new FormControl(''),
    })

    constructor(private http: HttpClient,
                private clientService: ClientService,
                private route: ActivatedRoute) {
    }

    ngOnInit(): void {

        this.route.params.subscribe(params => {
            this.clientId = +params['id']; // Converte o ID para número
        });
        this.getClient();
    }

    public getClient(): void {
        this.clientService.getClientById(this.clientId).subscribe({
            next: (client: Client) => {
                this.client = client;
            },
        })
    }

}
