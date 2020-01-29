import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AreaModel } from '../model/area.model';
import { AreaCrudService } from '../service/AreaCRUD.service';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css']

})

export class AreaComponent implements OnInit {
  display: string = null;
  title: string = null;

  togglePopUp: boolean = false;
  areaIdForDelete: number = null;
  area = new AreaModel();
  areaList: AreaModel[] = [];

  constructor(private crudService: AreaCrudService) { }

  ngOnInit() {
    this.display = "list";
    this.title = "Areas Listing";

    this.GetAllAreas();
  }

  GetAllAreas() {
    this.crudService.GetAll().subscribe(res => {
      let result = <AreaModel[]>res;
      this.areaList = result;
    });
  }

  GetAreaById(id: number) {
    this.crudService.GetById(id).subscribe(res => {
      let result = <AreaModel>res;
      if (result !== null) {
        this.display = "edit";
        this.area = result;
      } else {
        alert('Encountered an error.');
      }
    });
  }


  AddArea(form: NgForm) {
    this.area = <AreaModel>form.value;
    if (this.area.id > 0)
      return this.UpdateArea(this.area, form);

    else {
      this.area.id = 0;
      this.crudService.Create(this.area).subscribe(res => {
        let result = <boolean>res;
        if (result) {
          form.reset();
          this.display = "list";
          this.GetAllAreas();
          alert('New Area Added.');
        } else {
          alert('Encountered an error.');
        }
      });
    }
  }

  UpdateArea(area: AreaModel, form: NgForm) {
    this.crudService.Update(this.area).subscribe(res => {
      let result = <boolean>res;
      if (result) {
        form.reset();
        this.display = "list";
        this.title = "Updated Listing";
        this.GetAllAreas();
        alert('Area Information Updated.');
      } else {
        alert('Encountered an error.');
      }
    });
  }

  ConfirmDelete(id: number) {
    this.togglePopUp = true;
    this.areaIdForDelete = id;
  }

  DeleteArea() {
    this.crudService.Delete(this.areaIdForDelete).subscribe(res => {
      this.togglePopUp = false;
      let result = <boolean>res;
      if (result) {
        this.GetAllAreas();
        alert('Area Information Deleted.');
      } else {
        alert('Encountered an error.');
      }
    });
  }
}
