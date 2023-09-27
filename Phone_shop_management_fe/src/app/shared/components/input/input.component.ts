import { Component, Directive, forwardRef, Host, Input, OnInit, Optional, SkipSelf } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor, FormControl, ControlContainer } from '@angular/forms';

@Directive({
  selector: '[appInput]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true,
    },
  ],
})
export class InputComponent implements ControlValueAccessor, OnInit {
  onChange: any = () => {};
  onTouched: any = () => {};
  outerFormControl: FormControl;
  @Input() placeholder: string;
  @Input() required: boolean;
  @Input() formControlName: string;
  @Input('value') innerValue: string;

  constructor(
    @Optional() @Host() @SkipSelf()
    protected controlContainer: ControlContainer) {

  }

  ngOnInit() {
    if (this.controlContainer && this.formControlName) {
      this.outerFormControl = this.controlContainer.control.get(this.formControlName) as FormControl;
      const self = this;
      const originalFn = this.outerFormControl.markAsTouched;
      this.outerFormControl.markAsTouched = function () {
        originalFn.apply(this, arguments);
        self.validate(this);
      };
    }
  }

  validate(control: FormControl) {
    // Ajoutez votre logique de validation ici si nécessaire.
  }

  writeValue(value: string) {
    if (value !== this.innerValue) {
      this.innerValue = value;
    }
  }

  registerOnChange(fn: any) {
    this.onChange = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouched = fn;
  }
}
