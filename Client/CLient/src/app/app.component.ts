import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CLient';
  ShowEditor = false;
  public WriteMessage() {
      this.ShowEditor = true;
  }
}
