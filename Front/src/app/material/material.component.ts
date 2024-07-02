import {Component, OnInit, ViewChild} from '@angular/core';
import {Material} from "../../Model/material";
import {HttpClient} from "@angular/common/http";
import {MaterialService} from "../../Services/material.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.scss']
})
export class MaterialComponent implements OnInit {

  materials: Material[] | undefined;
  dataSource!: any;
  displayedColumns: string[] = ['id', 'type','createdBy','createdAt', 'actions'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient,
              private materialService: MaterialService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.getMaterials()
  }

  public getMaterials() {
    this.materialService.getMaterials().subscribe((materials: Material[]) => {
      this.materials = materials;
      this.dataSource = new MatTableDataSource<Material>(this.materials);
      this.dataSource.paginator = this.paginator;
    });
  }

  public deleteMaterial(id: number): void {
    this.materialService.deleteMaterials(id).subscribe(() => {
      this.getMaterials()
    })
  }

}
