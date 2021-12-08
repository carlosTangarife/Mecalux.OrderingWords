import { OrderOptionsVm } from '@orderWords/domain';

export abstract class IOrderWordsRepository {
    abstract GetOrderOptions(): Promise<Array<OrderOptionsVm>>;
}
