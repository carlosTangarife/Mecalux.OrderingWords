import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { GetOrderOptionsQry } from '@orderWords/application';
import { OrderOptionsVm } from '@orderWords/domain';

@Component({
  templateUrl: './order-words.component.html',
  styleUrls: ['./order-words.component.scss']
})
export class OrderWordsComponent implements OnInit {
  loginForm!: FormGroup;
  orderOptions!: Array<OrderOptionsVm>

  constructor(private readonly getOrderOptionsQry: GetOrderOptionsQry) { }

  ngOnInit(): void {
    this.getOrderOptions();
  }


  async getOrderOptions(): Promise<void> {
      this.orderOptions = await this.getOrderOptionsQry.execute();
  }
}
