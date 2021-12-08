import { Injectable } from '@angular/core';
import { Query } from '@archimedes/arch';
import { IOrderWordsRepository } from '@orderWords/application/repository';
import { TextStatistics } from '@orderWords/domain';

@Injectable()
export class GetStaticQry extends Query<TextStatistics, string> {
    constructor(private readonly orderWordsRepository: IOrderWordsRepository) {
        super();
    }

    async internalExecute(textToAnalize: string): Promise<TextStatistics> {
        return await this.orderWordsRepository.GetStatic(textToAnalize);
    }
}
