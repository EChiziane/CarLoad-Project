import {Component, Input, OnInit} from '@angular/core';
import {Guest} from "../../../Model/Guest";
import {HttpClient} from "@angular/common/http";
import {GuestService} from "../../../Services/guest.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-guest-details',
  templateUrl: './guest-details.component.html',
  styleUrls: ['./guest-details.component.scss']
})
export class GuestDetailsComponent implements OnInit {
  @Input() guestId!: number;
  guest!: Guest;

  constructor(private http: HttpClient,
              private clientService: GuestService,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      this.guestId = +params['id']; // Converte o ID para número
    });
    this.getGuest();

  }

  public getGuest(): void {
    this.clientService.getGuestById(this.guestId).subscribe({
      next: (guest: Guest) => {
        this.guest = guest;
      },
    })
  }


}
