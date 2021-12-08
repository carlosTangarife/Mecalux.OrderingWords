import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderWordsComponent } from '@orderWords/ui';

const routes: Routes = [{
  path: '',
  component: OrderWordsComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderWordsRoutingModule { }
