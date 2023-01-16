import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Dummyapiresult} from "../interfaces/dummyapiresult";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public dataEmployee: Dummyapiresult[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Dummyapiresult[]>(baseUrl + 'employee').subscribe({
      next: (result) => this.dataEmployee = result,
      error: (error) => console.error(error)
    })
  }

  ngOnInit(): void {
  }

}
