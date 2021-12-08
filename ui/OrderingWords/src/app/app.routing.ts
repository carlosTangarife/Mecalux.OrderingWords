/* eslint-disable @typescript-eslint/explicit-function-return-type */
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
      path: 'order-words',
      loadChildren: () => import('@orderWords/order-words.module').then((m) => m.OrderWordsModule),
    },
    {
        path: '**',
        redirectTo: 'order-words',
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule { }
