import { Component, forwardRef, Input, SecurityContext } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-html-editor',
  template: '<div [ngxSummernote]="config" [formControl]="formControl"></div>',
  styleUrls: ['./html-editor.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => HtmlEditorComponent),
      multi: true
    }     
  ]
})
export class HtmlEditorComponent implements ControlValueAccessor  {

  public formControl = new FormControl();

  @Input() public config: any = { height: 250 };
  
  constructor(
    private readonly _domSanitizer: DomSanitizer
  ) { }
  
  writeValue(obj: any): void {   
    this.formControl.setValue(obj, { emitEvent: false });
  }

  registerOnChange(fn: any): void {
    this.formControl.valueChanges
    .pipe(
      map(html => this._domSanitizer.sanitize(SecurityContext.HTML, html))
    )
    .subscribe(fn);
  }
  
  onTouched = () => {
  
  };

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.formControl.disable() : this.formControl.enable();
  }
}
