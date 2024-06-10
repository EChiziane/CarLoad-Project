import {Component, Input, OnInit} from '@angular/core';
import {CarLoad} from "../../../Model/car-load";
import {HttpClient} from "@angular/common/http";
import {CarloadService} from "../../../Services/carload.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-carload-details',
  templateUrl: './carload-details.component.html',
  styleUrls: ['./carload-details.component.scss']
})
export class CarloadDetailsComponent implements OnInit {
  @Input() carloadId!: number;
  carload!: CarLoad;

  constructor(private http: HttpClient,
              private carloadService: CarloadService,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.carloadId = +params['id'];
    });
    this.getCarload();
  }

  public getCarload(): void {
    this.carloadService.getCarLoadById(this.carloadId).subscribe({
      next: (carload: CarLoad) => {
        this.carload = carload;
      }
    })
  }

}
