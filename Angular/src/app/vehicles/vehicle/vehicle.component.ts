import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/shared/vehicle.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {

  constructor(private service : VehicleService,
    private toastr:ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

resetForm(form?:NgForm){
  if(form!=null)
  form.resetForm();
  this.service.formData={
    Id:null,
    Name:'',
    Abrv:'',
    Image:''
  }
}

onSubmit(form:NgForm){
  if(form.value.Id==null)
this.insertRecord(form);
else
this.updateRecord(form);
}

insertRecord(form:NgForm){
this.service.postVehicle(form.value).subscribe(res =>{
  this.toastr.success('Inserted successfully','VehicleMake');
this.resetForm(form);
this.service.refreshList();
});
}

updateRecord(form:NgForm){
this.service.putVehicle(form.value).subscribe(res =>{
  this.toastr.success('Updated successfully','VehicleMake');
this.resetForm(form);
this.service.refreshList();
});
}


}
