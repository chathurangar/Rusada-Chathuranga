import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-sight-list',
  templateUrl: './sight-list.component.html',
  styleUrls: ['./sight-list.component.css']
})
export class SightListComponent implements OnInit {

  constructor(private service:SharedService,
    private toastr:ToastrService) { }

  SightDetailsList:any=[];

  ModalTitle:string;
  ActivateAddEditSight:boolean=false;
  sight:any;

  SightFilter:string="";
  SightListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshSightDetailsList();
  }

  addClick(){
    this.sight={
      Id:0,
      Make:"",
      Model:"",
      Registration:"",
      Location:"",
      SightDate:new Date(),
      PhotoFileName:"anonymous.jpg"
    }
    this.ModalTitle="Add Sight";
    this.ActivateAddEditSight=true;
  }

  editClick(item){
    this.sight=item;
    this.ModalTitle="Edit Sight";
    this.ActivateAddEditSight=true;
  }

  deleteClick(item){
    if (confirm('Are you sure you want to delete this record?')){
       this.service.deleteSight(item.Id).subscribe(res=>{
        if(res){
          this.toastr.success('Sighting deleted successfully.');
        } else {
          this.toastr.error('Error occured while deleting data.');
        }
         this.refreshSightDetailsList();
       });
    }
  }

  refreshSightDetailsList(){
    this.service.getSightDetailsList().subscribe(data => {
      this.SightDetailsList = data;
      this.SightListWithoutFilter=data;
    });
  }

  closeClick(){
    this.ActivateAddEditSight=false;
    this.refreshSightDetailsList();
  }

  FilterFn(){
    var SightFilter = this.SightFilter;
    
    this.SightDetailsList = this.SightListWithoutFilter.filter(function (el){
      return el.Make.toString().toLowerCase().includes(
        SightFilter.toString().trim().toLowerCase()
      )||
      el.Model.toString().toLowerCase().includes(
        SightFilter.toString().trim().toLowerCase()
      )||
      el.Registration.toString().toLowerCase().includes(
        SightFilter.toString().trim().toLowerCase()
      )
    });
  }

}
