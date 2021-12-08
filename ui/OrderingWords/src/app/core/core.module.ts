import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Injector, NgModule, Optional, SkipSelf } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CacheLink, CacheManager, ExecutorLink, LoggerLink, Runner } from '@archimedes/arch';
import { environment } from '@environment/environment';

const MODULES = [CommonModule, BrowserModule, BrowserAnimationsModule, HttpClientModule];

@NgModule({
    declarations: [],
    imports: [...MODULES],
    exports: [...MODULES],
    providers:[
      { provide: LoggerLink, useFactory: () => new LoggerLink(console) },
      { provide: ExecutorLink, useClass: ExecutorLink },
      { provide: CacheManager, useClass: CacheManager },
      { provide: CacheLink, useClass: CacheLink, deps: [CacheManager] }
    ]
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() core: CoreModule, private readonly injector: Injector) {
        if (core) {
            throw new Error('Application requires single instance of CoreModule.');
        }
        const cacheLink = this.injector.get(CacheLink)
        const executorLink = this.injector.get(ExecutorLink)
        const links = [cacheLink, executorLink];

        if (!environment.production) {
          const loggerLink = this.injector.get(LoggerLink)
          links.push(loggerLink)
        }
        Runner.createChain(links)
    }
}
