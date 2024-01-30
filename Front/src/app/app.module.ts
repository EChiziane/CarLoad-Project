import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {GuestComponent} from './guest/guest.component';
import {HttpClientModule} from "@angular/common/http";
import {AddGuestComponent} from './guest/add-guest/add-guest.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {GuestDetailsComponent} from './guest/guest-details/guest-details.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatButtonModule} from "@angular/material/button";
import {MatTableModule} from "@angular/material/table";
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatIconModule} from "@angular/material/icon";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {DriverComponent} from './driver/driver.component';
import {AddDriverComponent} from './driver/add-driver/add-driver.component';
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {DriverDetailsComponent} from './driver/driver-details/driver-details.component';
import {CarLoadComponent} from './car-load/car-load.component';
import {AddCarloadComponent} from './car-load/add-carload/add-carload.component';
import {CarloadDetailsComponent} from './car-load/carload-details/carload-details.component';
import {ClientComponent} from './client/client.component';
import {MatSelectModule} from "@angular/material/select";
import {AddClientComponent} from './client/add-client/add-client.component';
import {ClientDetailsComponent} from './client/client-details/client-details.component';
import {MaterialComponent} from './material/material.component';
import {AddMaterialComponent} from './material/add-material/add-material.component';
import {MaterialDetailsComponent} from './material/material-details/material-details.component';
import {ManagerComponent} from './manager/manager.component';
import {AddManagerComponent} from './manager/add-manager/add-manager.component';
import { LayoutComponent } from './layout/layout.component';
import {MatSidenavModule} from "@angular/material/sidenav";
import { SideNavComponent } from './layout/side-nav/side-nav.component';
import {MatListModule} from "@angular/material/list";
import {MatTabsModule} from "@angular/material/tabs";
import { CloadComponent } from './cload/cload.component';


@NgModule({
    declarations: [
        AppComponent,
        GuestComponent,
        AddGuestComponent,
        GuestDetailsComponent,
        DriverComponent,
        AddDriverComponent,
        DriverDetailsComponent,
        CarLoadComponent,
        AddCarloadComponent,
        CarloadDetailsComponent,
        ClientComponent,
        AddClientComponent,
        ClientDetailsComponent,
        MaterialComponent,
        AddMaterialComponent,
        MaterialDetailsComponent,
        ManagerComponent,
        AddManagerComponent,
        LayoutComponent,
        SideNavComponent,
        CloadComponent,

    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MatSlideToggleModule,
        MatButtonModule,
        MatTableModule,
        MatPaginatorModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDatepickerModule,
        FormsModule,
        MatNativeDateModule,
        MatSelectModule,
        MatSidenavModule,
        MatListModule,
        MatTabsModule,

    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
