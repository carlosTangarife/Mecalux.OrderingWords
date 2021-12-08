import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GetOrderOptionsQry, GetStaticQry } from '@orderWords/application';
import { OrderOptionsVm, TextStatistics } from '@orderWords/domain';

@Component({
  templateUrl: './order-words.component.html',
  styleUrls: ['./order-words.component.scss']
})
export class OrderWordsComponent implements OnInit {
  orderWordsForm!: FormGroup;
  orderOptions!: Array<OrderOptionsVm>
  textStatistics!: TextStatistics;

  constructor(
    private readonly fb: FormBuilder,
    private readonly getOrderOptionsQry: GetOrderOptionsQry,
    private readonly getStaticQry: GetStaticQry
  ) { }

  ngOnInit(): void {
    this.getOrderOptions();
    this.buildForm();
  }

  buildForm(): void {
    this.orderWordsForm = this.fb.group({
      orderOption: [''],
      textToProcess: ['', Validators.required],
    });
  }

  async getOrderOptions(): Promise<void> {
    this.orderOptions = await this.getOrderOptionsQry.execute();
  }

  async processAnalize(): Promise<void> {
    this.textStatistics = await this.getStaticQry.execute(this.orderWordsForm.get('textToProcess')?.value);
  }
}
