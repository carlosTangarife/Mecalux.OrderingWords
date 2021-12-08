import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GetOrderedTextQry, GetStaticQry, IOrderWordsRepository } from '@orderWords/application';
import { OrderWordsRepository } from '@orderWords/infraestructure';
import { SharedModule } from '@shared/shared.module';

import { GetOrderOptionsQry } from './application/use-cases/get-order-options-qry';
import { OrderWordsRoutingModule } from './order-words.routing';
import { OrderWordsComponent } from './ui/pages/order-words/order-words.component';

@NgModule({
  declarations: [OrderWordsComponent],
  imports: [
    CommonModule,
    OrderWordsRoutingModule,
    SharedModule
  ],
  providers: [
    {provide: IOrderWordsRepository, useClass: OrderWordsRepository},
    GetOrderOptionsQry,
    GetStaticQry,
    GetOrderedTextQry
  ]
})
export class OrderWordsModule { }
