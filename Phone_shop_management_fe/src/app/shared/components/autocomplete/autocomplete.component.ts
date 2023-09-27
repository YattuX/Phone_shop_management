import { 
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  ElementRef, 
  EventEmitter, 
  Host,
  Input, 
  OnInit, 
  Optional, 
  ViewChild, 
  forwardRef, 
  OnChanges, 
  SimpleChanges,
  SkipSelf, 
  Output 
} from '@angular/core';
import { 
  AbstractControl,
  FormControl, 
  ControlContainer,
  ControlValueAccessor, 
  NG_VALUE_ACCESSOR, 
  NG_VALIDATORS, 
  Validator,
  ReactiveFormsModule,
  FormsModule,
} from '@angular/forms';

import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { InputComponent } from '../input/input.component';
import { MatChipsModule } from '@angular/material/chips';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

export interface AutoCompleteValueChangeEvent {
  value?: any;
}

@Component({
  selector: 'autocomplete',
  templateUrl: 'autocomplete.component.html',
  standalone: true,
  imports : [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatInputModule,
    MatChipsModule,
    MatAutocompleteModule,
  ],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AutoCompleteComponent),
      multi: true,
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => AutoCompleteComponent),
      multi: true,
    }
  ],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AutoCompleteComponent extends InputComponent 
  implements OnInit, OnChanges, ControlValueAccessor, Validator {

  @Input() values;

  @Input() multipleSelection: boolean;

  @Input() idField = 'id';

  @Input() valueField = 'value';

  @Output() valueChange = new EventEmitter<AutoCompleteValueChangeEvent>();

  public multipleSelectedValues: Array<any>;

  public singleSelectedValue: any;

  public filteredValues: Observable<any[]>;

  @ViewChild('autoCompleteInput') autoCompleteInput: ElementRef;
  autoCompleteControl: FormControl;

  constructor(@Optional() @Host() @SkipSelf()
    protected override controlContainer: ControlContainer,
    private _cdRef: ChangeDetectorRef) {
    super(controlContainer);
    this.autoCompleteControl = new FormControl('');
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['values']) {
      if (!this.multipleSelection) {
        this.autoCompleteControl.setValue(this.getDisplayName(this.singleSelectedValue));
      }

      if (!this.filteredValues) {
        this.filteredValues = this.autoCompleteControl.valueChanges
          .pipe(
            startWith(''),
            map(val => {
              if (!this.multipleSelection && this.singleSelectedValue
                && this.getDisplayName(this.singleSelectedValue) === val) {
                return this.values;
              }
              if (!this.values || (val && typeof val !== 'string')) {
                return [];
              } else {
                return this._filterValues(val ? val : '');
              }
            })
          );
      }
    }
  }

  public override validate(control: AbstractControl) {
    var emptyValue = this.multipleSelection && (!this.multipleSelectedValues || this.multipleSelectedValues.length == 0)
       || !this.multipleSelection && !this.singleSelectedValue;
    var error = this.required && emptyValue ? { 'required': true } : null;
    if (control) {
      control.setErrors(error);
    }
    this.autoCompleteControl.setErrors(error);
    this.autoCompleteControl.markAsTouched();
    this._cdRef.detectChanges();
    return error;
  }

  public override writeValue(obj: any) {
    if (this.multipleSelection) {
      this.multipleSelectedValues = obj;
    } else {
      this.singleSelectedValue = obj;
      this.autoCompleteControl.setValue(this.getDisplayName(this.singleSelectedValue));
    }
  }

  public addValue(event: MatAutocompleteSelectedEvent): void {
    let idValue = event.option.value[this.idField];

    if (this.multipleSelection) { 
      if (!this.multipleSelectedValues) {
        this.multipleSelectedValues = [];
      }
      if (this._indexOfSelected(idValue) < 0) {
        this.multipleSelectedValues.push(idValue);
      }
      this.autoCompleteControl.setValue(null);
      this.autoCompleteInput.nativeElement.value = '';
      this.valueChange.emit({value: this.multipleSelectedValues});
      this.onChange(this.multipleSelectedValues);
    } else {
      this.singleSelectedValue = idValue;
      this.autoCompleteControl.setValue(event.option.value[this.valueField]);
      this.valueChange.emit({value: this.singleSelectedValue});
      this.onChange(this.singleSelectedValue);
    }
  }

  public removeValue(value: any): void {
    var index = this._indexOfSelected(value);
    if (index > -1) {
      this.multipleSelectedValues.splice(index, 1);
    }
    this.autoCompleteControl.setValue(null);
    this.validate(null);
    this.onChange(this.multipleSelectedValues);
  }

  public forceValueSelection(): void {
    setTimeout(() => {
      if (this.getDisplayName(this.singleSelectedValue) !== this.autoCompleteControl.value) {
        this.singleSelectedValue = '';
        this.autoCompleteControl.setValue('');
        this.valueChange.emit({value: this.singleSelectedValue});
        this.onChange(this.singleSelectedValue);
      }
    }, 300);
  }

  private _filterValues(value: string): any[] {
    return this.values.filter(item =>
      (item[this.valueField].toLowerCase().startsWith(value.toLowerCase())) &&
      this._indexOfSelected(item[this.idField]) < 0);
  }

  public getDisplayName(id: string): string {
    if (!this.values || this.values.length == 0) {
      return null;
    }
    var index = this.values.findIndex(data => id == data[this.idField]);
    if (index == -1) {
      return null;
    }
    return this.values[index][this.valueField];
  }

  private _indexOfSelected(itemId: string): number {
    return this.multipleSelectedValues ? this.multipleSelectedValues.findIndex(id => id == itemId) : -1;
  }
}