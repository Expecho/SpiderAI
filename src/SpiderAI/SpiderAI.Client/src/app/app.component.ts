import { Component } from '@angular/core';
import { ChatapiService } from './chatapi.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SpiderAI.Client';
  data: any;

  constructor(private apiService: ChatapiService) { }

  ngOnInit(): void {
    this.apiService.getData().subscribe(response => {
      this.data = response;
    });
  }
}
