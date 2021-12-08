import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GetOrderedTextQry, GetOrderOptionsQry, GetStaticQry } from '@orderWords/application';
import { OrderOptionsVm, TextStatistics } from '@orderWords/domain';

@Component({
    templateUrl: './order-words.component.html',
    styleUrls: ['./order-words.component.scss']
})
export class OrderWordsComponent implements OnInit {
    orderWordsForm!: FormGroup;
    orderOptions!: Array<OrderOptionsVm>
    textStatistics!: TextStatistics;
    listOrderedText!: Array<string>;

    constructor(
        private readonly fb: FormBuilder,
        private readonly getOrderOptionsQry: GetOrderOptionsQry,
        private readonly getStaticQry: GetStaticQry,
        private readonly getOrderedTextQry: GetOrderedTextQry,
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

    async processToAnalize(): Promise<void> {
        this.orderWordsForm.get('orderOption')?.setValidators(null);
        this.orderWordsForm.get('textToProcess')?.setValidators(Validators.required);
        this.resetValidator('orderOption');
        this.resetValidator('textToProcess');
        debugger
        if (this.orderWordsForm.valid) {
            this.textStatistics = await this.getStaticQry.execute(this.orderWordsForm.get('textToProcess')?.value);
        }
    }

    async processToOrder(): Promise<void> {
        this.orderWordsForm.get('orderOption')?.setValidators(Validators.required);
        this.orderWordsForm.get('textToProcess')?.setValidators(Validators.required);
        this.resetValidator('orderOption');
        this.resetValidator('textToProcess');
        this.listOrderedText = new Array<string>();

        if (this.orderWordsForm.valid) {
            this.listOrderedText = await this.getOrderedTextQry.execute(this.orderWordsForm.value);
        }
    }

    resetValidator(field: string): void {
        this.orderWordsForm.get(field)?.markAsTouched();
        this.orderWordsForm.get(field)?.updateValueAndValidity();
    }
}
