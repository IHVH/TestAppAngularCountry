import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public text: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    
  }

  title = 'testappangularcountry.client';
}
