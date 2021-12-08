import { lastValueFrom } from 'rxjs';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface Options {
    headers?: HttpHeaders;
    params?: HttpParams;
}

@Injectable()
export class HttpService {
    constructor(private readonly http: HttpClient) {}

    public createDefaultOptions(): Options {
        return {
            headers: new HttpHeaders({
                Accept: 'application/json',
                'Content-Type': 'application/json',
            }),
        };
    }

    public optsName(name: string): Options {
        return this.setHeader('xhr-name', name);
    }

    private setHeader(name: string, value: string): Options {
        const newOpts = this.createDefaultOptions();
        newOpts.headers = newOpts.headers?.set(name, value);
        return newOpts;
    }

    private createOptions(opts?: Options): Options {
        const defaultOpts: Options = this.createDefaultOptions();

        if (!!opts) {
            opts = {
                params: opts.params || defaultOpts.params,
                headers: opts.headers || defaultOpts.headers,
            };

            if (!opts.headers?.get('Content-Type')) {
                opts.headers?.set('Content-Type', defaultOpts.headers?.get('Content-Type') || '');
            }
        }

        return opts || defaultOpts;
    }

    public get<T>(serviceUrl: string, opts?: Options): Promise<T> {
        const _opts = this.createOptions(opts);
        const response$ = this.http.get<T>(serviceUrl, _opts);
        return lastValueFrom(response$);
    }

    public getParameters<T>(serviceUrl: string, params: HttpParams, opts?: Options): Promise<T> {
        const _opts = this.createOptions(opts);
        const options =
            params !== null
                ? ({
                      headers: _opts.headers,
                      params: params,
                  } as Options)
                : _opts;

        const response$ = this.http.get<T>(serviceUrl, options);
        return lastValueFrom(response$);
    }
}
