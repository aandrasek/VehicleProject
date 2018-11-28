import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/shared/vehicle.service';
import { Vehicle } from 'src/app/shared/vehicle.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  constructor(private service :VehicleService,
    private toastr:ToastrService) { }

  ngOnInit() {
   this.service.refreshList();
  }

  populateForm(make : Vehicle){
    this.service.formData=Object.assign({},make);
  }

  onDelete(id:number){
    if(confirm('Are you sure you want to delete this?'))
    this.service.deleteVehicle(id).subscribe(res =>{
   this.service.refreshList();
  this.toastr.warning('Deleted successfully','VehicleMake');
    });
  }
}
