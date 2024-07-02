import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DriverComponent} from "./driver/driver.component";
import {AddDriverComponent} from "./driver/add-driver/add-driver.component";
import {DriverDetailsComponent} from "./driver/driver-details/driver-details.component";
import {CarLoadComponent} from "./car-load/car-load.component";
import {AddCarloadComponent} from "./car-load/add-carload/add-carload.component";
import {CarloadDetailsComponent} from "./car-load/carload-details/carload-details.component";
import {ClientComponent} from "./client/client.component";
import {AddClientComponent} from "./client/add-client/add-client.component";
import {ClientDetailsComponent} from "./client/client-details/client-details.component";
import {MaterialComponent} from "./material/material.component";
import {AddMaterialComponent} from "./material/add-material/add-material.component";
import {ManagerComponent} from "./manager/manager.component";
import {AddManagerComponent} from "./manager/add-manager/add-manager.component";

import {SprintComponent} from "./sprint/sprint.component";
import {AddSprintComponent} from "./sprint/add-sprint/add-sprint.component";
import {ListCarloadsComponent} from "./sprint/list-carloads/list-carloads.component";

const routes: Routes = [
  {path: 'driver', component: DriverComponent},
  {path: 'driver/create', component: AddDriverComponent},
  {path: 'driver/detail/:id', component: DriverDetailsComponent},
  {path: 'carload', component: CarLoadComponent},
  {path: 'carload/create', component: AddCarloadComponent},
  {path: 'carload/detail/:id', component: CarloadDetailsComponent},
  {path: 'client', component: ClientComponent},
  {path: 'client/create', component: AddClientComponent},
  {path: 'detail/:id', component: ClientDetailsComponent},
  {path: 'material', component: MaterialComponent},
  {path: 'material/create', component: AddMaterialComponent},
  {path: 'manager', component: ManagerComponent},
  {path: 'manager/create', component: AddManagerComponent},
  {path: 'sprint', component: SprintComponent},
  {path: 'sprint/create', component: AddSprintComponent},
  {path: 'sprint/list/:id', component: ListCarloadsComponent},
  {path: '', component: CarLoadComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
