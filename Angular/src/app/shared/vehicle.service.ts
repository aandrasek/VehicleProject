import { Injectable } from '@angular/core';
import { Vehicle } from './vehicle.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

formData : Vehicle;
list: Vehicle[];
readonly rootURL="http://localhost:65131/api"

  constructor(protected http : HttpClient) { }

  postVehicle(formData:Vehicle){
 return  this.http.post(this.rootURL+'/VehicleMake',formData);
  }

  refreshList(){
    this.http.get(this.rootURL+'/VehicleMake').toPromise().then(res=>this.list=res as Vehicle[]);
  }

  putVehicle(formData:Vehicle){
    return this.http.put(this.rootURL+'/VehicleMake/'+formData.Id,formData);
  }

  deleteVehicle(id :number){
    return this.http.delete(this.rootURL+'/VehicleMake/'+id);
  }
}
