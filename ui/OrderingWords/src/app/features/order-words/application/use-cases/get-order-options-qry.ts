import { Injectable } from '@angular/core';
import { Query } from '@archimedes/arch';
import { IOrderWordsRepository } from '@orderWords/application/repository';
import { OrderOptionsVm } from '@orderWords/domain';

@Injectable()
export class GetOrderOptionsQry extends Query<Array<OrderOptionsVm>> {
    constructor(private readonly orderWordsRepository: IOrderWordsRepository) {
        super();
    }

    async internalExecute(): Promise<Array<OrderOptionsVm>> {
        return await this.orderWordsRepository.GetOrderOptions();
    }
}
