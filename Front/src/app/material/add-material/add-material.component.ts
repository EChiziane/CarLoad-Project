import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MaterialService} from "../../../Services/material.service";

@Component({
    selector: 'app-add-material',
    templateUrl: './add-material.component.html',
    styleUrls: ['./add-material.component.scss']
})
export class AddMaterialComponent implements OnInit {

    profileForm = new FormGroup({
        type: new FormControl(''),
    })

    constructor(private http: HttpClient,
                private materialService: MaterialService,
                private router: Router) {
    }

    ngOnInit(): void {
    }

    public createMaterial(): void {
        this.materialService.addMaterial(this.profileForm.value).subscribe(() => {
            this.router.navigate([''])
        })


    }

    public cancelOperation(): void {
        this.router.navigate(['']);
    }


}
