import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ChatapiService } from '../../chatapi.service';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-user-input',
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.css']
})
export class UserInputComponent {
  textInput = new FormControl('', [Validators.required]);

  constructor(private chatApi: ChatapiService) {}

  async onSubmit() {
    if (this.textInput.valid && this.textInput.value) {
      try {
        const response = await this.chatApi.getData(this.textInput.value).toPromise();
        console.log('Response:', response);
      } catch (error) {
        console.error('Error:', error);
      }
    }
  }
}
