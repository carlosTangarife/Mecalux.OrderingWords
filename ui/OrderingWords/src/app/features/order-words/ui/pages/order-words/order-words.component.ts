import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GetOrderOptionsQry } from '@orderWords/application';
import { OrderOptionsVm } from '@orderWords/domain';

@Component({
  templateUrl: './order-words.component.html',
  styleUrls: ['./order-words.component.scss']
})
export class OrderWordsComponent implements OnInit {
  orderWordsForm!: FormGroup;
  orderOptions!: Array<OrderOptionsVm>

  constructor(private readonly fb: FormBuilder, private readonly getOrderOptionsQry: GetOrderOptionsQry) { }

  ngOnInit(): void {
    this.getOrderOptions();
    this.buildForm();
  }

  buildForm(): void {
    this.orderWordsForm = this.fb.group({
      orderOption: ['', Validators.required],
      textToProcess: ['', Validators.required],
    });
  }

  async getOrderOptions(): Promise<void> {
      this.orderOptions = await this.getOrderOptionsQry.execute();
  }
}
