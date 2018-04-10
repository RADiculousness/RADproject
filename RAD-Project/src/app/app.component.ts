import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'hammerjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  verified: Observable<boolean>;

  title = 'app';
}
