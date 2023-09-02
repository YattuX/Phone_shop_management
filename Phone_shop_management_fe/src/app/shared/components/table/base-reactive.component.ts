import { Directive, OnDestroy } from "@angular/core";
import { Subject } from "rxjs";

@Directive()
export abstract class BaseReactiveComponent implements OnDestroy{
    protected readonly $ngOnDestroyed:Subject<any> = new Subject<any>();

    ngOnDestroy(): void {
        this.$ngOnDestroyed.next(null);
        this.$ngOnDestroyed.complete();
    }
}