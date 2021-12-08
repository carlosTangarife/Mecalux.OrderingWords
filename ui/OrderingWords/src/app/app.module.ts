import { NgModule } from '@angular/core';
import { CoreModule } from '@core/core.module';
import { OrderWordsModule } from '@orderWords/order-words.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CoreModule,
    OrderWordsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
