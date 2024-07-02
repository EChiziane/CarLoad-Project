import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {SprintService} from "../../../Services/sprint.service";
import {Router} from "@angular/router";
import {Driver} from "../../../Model/driver";
import {DriverService} from "../../../Services/driver.service";

@Component({
  selector: 'app-add-sprint',
  templateUrl: './add-sprint.component.html',
  styleUrls: ['./add-sprint.component.scss']
})
export class AddSprintComponent implements OnInit {
  drivers!: Driver[];
  sprintForm = new FormGroup({
    name: new FormControl(''),
    driverId: new FormControl('')
  });

  constructor(
    private http: HttpClient,
    private sprintService: SprintService,
    private driverService: DriverService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.getDrivers();
  }

  public createSprint(): void {
    this.sprintService.addSprint(this.sprintForm.value).subscribe(() => {
      this.router.navigate(['/sprint']);
    });
  }

  public cancelOperation(): void {
    this.router.navigate(['/sprint']);
  }


  public getDrivers(): void {
    this.driverService.getDriver().subscribe({
      next: (drivers: Driver[]) => {
        this.drivers = drivers;
      }
    })
  }
}
