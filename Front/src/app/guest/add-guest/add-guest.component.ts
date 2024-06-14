import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Guest} from "../../../Model/Guest";
import {HttpClient} from "@angular/common/http";
import {GuestService} from "../../../Services/guest.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-guest',
  templateUrl: './add-guest.component.html',
  styleUrls: ['./add-guest.component.scss']
})
export class AddGuestComponent implements OnInit {


  // Definindo um formulário reativo com controles para name, email e confirm
  profileForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    confirm: new FormControl(true),
  });

  // Inicializando um objeto Guest com valores do formulário
  guest: Guest = {
    id: 0,
    name: this.profileForm.controls.name.value!,
    email: this.profileForm.value.email!,
    confirm: true
  };

  constructor(private http: HttpClient,
              private clientService: GuestService,
              private router: Router) {
  }

  // Método para criar um novo convidado
  public createClient(): void {

    this.clientService.addGuest(this.profileForm.value).subscribe(() => {
      this.router.navigate([''])
    });
  }


  ngOnInit(): void {
  }


  public cancelOperation(): void {
    this.router.navigate(['']);
  }
}
