import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from "./app.component";
import {HttpClientModule} from "@angular/common/http";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {AppRoutingModule} from "./app-routing.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {MatTableModule} from "@angular/material/table";
import {MatButtonModule} from "@angular/material/button";
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatSelectModule} from "@angular/material/select";
import {MatTabsModule} from "@angular/material/tabs";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatListModule} from "@angular/material/list";
import {MatNativeDateModule} from "@angular/material/core";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatInputModule} from "@angular/material/input";
import {DriverDetailsComponent} from "./driver/driver-details/driver-details.component";
import {AddClientComponent} from "./client/add-client/add-client.component";
import {ClientComponent} from "./client/client.component";
import {CarloadDetailsComponent} from "./car-load/carload-details/carload-details.component";
import {AddCarloadComponent} from "./car-load/add-carload/add-carload.component";
import {CarLoadComponent} from "./car-load/car-load.component";
import {ClientDetailsComponent} from "./client/client-details/client-details.component";
import {MaterialComponent} from "./material/material.component";
import {AddMaterialComponent} from "./material/add-material/add-material.component";
import {MaterialDetailsComponent} from "./material/material-details/material-details.component";
import {ManagerComponent} from "./manager/manager.component";
import {AddManagerComponent} from "./manager/add-manager/add-manager.component";
import {LayoutComponent} from "./layout/layout.component";
import {SideNavComponent} from "./layout/side-nav/side-nav.component";
import {DriverComponent} from "./driver/driver.component";
import {AddDriverComponent} from "./driver/add-driver/add-driver.component";
import {ModelagemComponent} from './modelagem/modelagem.component';
import {SprintComponent} from './sprint/sprint.component';
import {AddSprintComponent} from './sprint/add-sprint/add-sprint.component';
import {ListCarloadsComponent} from './sprint/list-carloads/list-carloads.component';

import { DasboardComponent } from './dasboard/dasboard.component';
import {SidebarComponent} from "./dasboard/sidebar/sidebar.component";
import {HeaderComponent} from "./dasboard/header/header.component";
import {ContentComponent} from "./dasboard/content/content.component";
import { CalendarComponent } from './calendar/calendar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
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
    ModelagemComponent,
    SprintComponent,
    AddSprintComponent,
    ListCarloadsComponent,
    HeaderComponent,
    SidebarComponent,
    ContentComponent,
    DasboardComponent,
    CalendarComponent,

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
    NgbModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
