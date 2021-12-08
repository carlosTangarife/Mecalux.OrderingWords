import { Injectable } from '@angular/core';
import { Query } from '@archimedes/arch';
import { IOrderWordsRepository } from '@orderWords/application/repository';
import { OrderedText } from '@orderWords/domain';

@Injectable()
export class GetOrderedTextQry extends Query<Array<string>, OrderedText> {
    constructor(private readonly orderWordsRepository: IOrderWordsRepository) {
        super();
    }

    async internalExecute(orderedText: OrderedText): Promise<Array<string>> {
        return await this.orderWordsRepository.GetOrderedText(orderedText);
    }
}
