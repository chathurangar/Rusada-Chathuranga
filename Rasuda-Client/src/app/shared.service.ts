import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = 'http://localhost:5000/api';
  readonly PhotoUrl = 'http://localhost:5000/Photos/';

  constructor(private http:HttpClient) { }

  getDepList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/department');
  }

  addDepartment(val:any){
    return this.http.post(this.APIUrl+'/Department',val);
  }

  updateDepartment(val:any){
    return this.http.put(this.APIUrl+'/Department',val);
  }

  deleteDepartment(val:any){
    return this.http.delete(this.APIUrl+'/Department/'+val);
  }

  getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }

  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Employee',val);
  }

  updateEmployee(val:any){
    return this.http.put(this.APIUrl+'/Employee',val);
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Employee/'+val);
  }

  getAllDepartmentNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Employee/GetAllDepartmentNames');
  }

  
  getSightDetailsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Sight/GetAllSightDetails');
  }

  addSight(val:any){
    return this.http.post(this.APIUrl+'/Sight/InsertSight',val);
  }

  updateSight(val:any){
    return this.http.put(this.APIUrl+'/Sight/UpdateSight',val);
  }

  deleteSight(val:any){
    return this.http.delete(this.APIUrl+'/Sight/DeleteSight/'+val);
  }

  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Sight/SaveFile',val);
  }
}
