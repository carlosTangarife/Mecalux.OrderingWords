import { OrderOptionsVm, TextStatistics } from '@orderWords/domain';

export abstract class IOrderWordsRepository {
    abstract GetOrderOptions(): Promise<Array<OrderOptionsVm>>;

    abstract GetStatic(textToAnalize: string): Promise<TextStatistics>;
}
