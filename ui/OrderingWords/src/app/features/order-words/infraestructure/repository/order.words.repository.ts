import { Injectable } from '@angular/core';
import { environment } from '@environment/environment';
import { IOrderWordsRepository } from '@orderWords/application';
import { OrderedText, OrderOptionsVm, TextStatistics } from '@orderWords/domain';
import { HttpService } from '@shared/services/http.service';

@Injectable()
export class OrderWordsRepository extends IOrderWordsRepository {
    baseUrl = environment.baseUrl;

    constructor(private readonly http: HttpService) {
        super();
    }

    GetOrderOptions(): Promise<Array<OrderOptionsVm>> {
        return this.http.get(`${this.baseUrl}/OrderWords/GetOrderOptions`);

    }

    GetStatic(textToAnalize: string): Promise<TextStatistics> {
        return this.http.get(`${this.baseUrl}/OrderWords/GetStatic?textToAnalize=${textToAnalize}`);
    }

    GetOrderedText(orderedText: OrderedText): Promise<Array<string>> {
        return this.http.get(`${this.baseUrl}/OrderWords/GetOrderedText?textToOrder=${orderedText.textToProcess}&orderOptions=${orderedText.orderOption}`);
    }
}
