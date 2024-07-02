import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ClientService} from "../../../Services/client.service";

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.scss']
})
export class AddClientComponent implements OnInit {

  profileForm = new FormGroup({
    name: new FormControl(''),
    phoneNumber: new FormControl(''),
  })

  constructor(private http: HttpClient,
              private clientService: ClientService,
              private router: Router) {
  }

  ngOnInit(): void {
  }

  public createClient(): void {
    this.clientService.addClient(this.profileForm.value).subscribe(() => {
      this.router.navigate(['/client'])
    })
  }

  public cancelOperation(): void {
    this.router.navigate(['/client']);
  }


}
