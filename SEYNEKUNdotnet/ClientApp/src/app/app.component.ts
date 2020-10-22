import { Component } from '@angular/core';
import { MaterialModule } from './material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  imports: [MaterialModule]; /*importo mi clase material para usuar los componentes de angular material*/

}
