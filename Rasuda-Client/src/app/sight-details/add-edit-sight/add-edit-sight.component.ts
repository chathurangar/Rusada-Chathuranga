import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-sight',
  templateUrl: './add-edit-sight.component.html',
  styleUrls: ['./add-edit-sight.component.css']
})
export class AddEditSightComponent implements OnInit {

  constructor(private service:SharedService,
    private toastr:ToastrService) { }

  @Input() sight:any;
  Id: string;
  Make: string;
  Model: string;
  Registration: string;
  Location: string;
  SightDate: string;
  PhotoFileName:string;
  PhotoFilePath:string;
  RowVersion:string;

  ngOnInit(): void {
    this.loadData();
  }

  time = {hour: 0, minute: 0};
  spinners = false;

  toggleSpinners() {
      this.spinners = !this.spinners;
  }

  loadData(){
    var sDate = new Date(this.sight.SightDate);
    this.Id = this.sight.Id;
    this.Make = this.sight.Make;
    this.Model = this.sight.Model;
    this.Registration = this.sight.Registration;
    this.Location = this.sight.Location;
    this.time.hour = sDate.getHours();
    this.time.minute = sDate.getMinutes();
    this.SightDate = this.formatDate(sDate);
    this.PhotoFileName = this.sight.PhotoFileName;
    this.PhotoFilePath = this.service.PhotoUrl+this.PhotoFileName;
    this.RowVersion = this.sight.RowVersion;
  }

  addSight(){

    var sDate = new Date(this.SightDate);
    sDate.setHours(this.time.hour);
    sDate.setMinutes(this.time.minute);

    var currentDateTime = new Date();

    if(sDate > currentDateTime){
      this.toastr.error('Date cannot be in the future.', 'Please select a valid date time');
      return;
    }


    var val = {Id: this.Id,
    Make: this.Make,
    Model: this.Model,
    Registration: this.Registration,
    Location: this.Location,
    SightDate: sDate.toLocaleString(),
    PhotoFileName: this.PhotoFileName};

    this.service.addSight(val).subscribe(res=>{
      if(res > 0){
        this.toastr.success('New sighting added successfully.');
      } else {
        this.toastr.error('Error occured while saving data.');
      }
      
    });
  }

  updateSight(){
    var sDate = new Date(this.SightDate);
    sDate.setHours(this.time.hour);
    sDate.setMinutes(this.time.minute);

    var currentDateTime = new Date();

    if(sDate > currentDateTime){
      this.toastr.error('Date cannot be in the future.', 'Please select a valid date time');
      return;
    }

    var val = {Id:this.Id,
    Make: this.Make,
    Model: this.Model,
    Registration: this.Registration,
    Location: this.Location,
    SightDate: sDate.toLocaleString(),
    PhotoFileName: this.PhotoFileName,
    RowVersion: this.RowVersion};

      this.service.updateSight(val).subscribe((res:any)=>{
        if(res.isSuccess){
          this.toastr.success('Sighting updated successfully.');
        } else {
          this.toastr.error(res.errorMessage);
        }
      });
  }

  uploadPhoto(event){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile', file, file.name);

    this.service.UploadPhoto(formData).subscribe((data:any)=>{
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;      
    })
  }

  formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('-');
}

}
