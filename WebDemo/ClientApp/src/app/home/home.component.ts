import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(
      private apiService: ApiService
  ) { }


  ngOnInit() {
      this.callGetClients();
    }

  callGetClients() {
    this.apiService.getClients().subscribe((response) => {
        console.log(response);
    },
    (error: HttpErrorResponse) => {
    });
  }

}

