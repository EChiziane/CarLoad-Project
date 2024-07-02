import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {ManagerService} from "../../../Services/manager.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-manager',
  templateUrl: './add-manager.component.html',
  styleUrls: ['./add-manager.component.scss']
})
export class AddManagerComponent implements OnInit {
  profileForm = new FormGroup({
    name: new FormControl(''),
    phoneNumber: new FormControl(''),
    email: new FormControl('')
  })

  constructor(private http: HttpClient,
              private managerService: ManagerService,
              private router: Router) {
  }

  ngOnInit(): void {
  }

  public createManager(): void {
    this.managerService.addManager(this.profileForm.value).subscribe(() => {
      this.router.navigate(['/manager'])
    })
  }

  public cancelOperation(): void {
    this.router.navigate(['/manager']);
  }
}
