import { ValidatorFn, FormGroup, ValidationErrors, AbstractControl, Validators } from '@angular/forms';

/**
 * Validates whether any of the subControls of a FormGroup has no value
 */
export const checkboxRequired: ValidatorFn = (control: FormGroup): ValidationErrors | null => {

  control.markAsTouched();
  let checked = 0;

  Object.values(control.controls).forEach((subControl: AbstractControl) => {

    if (subControl.value === false) {
      checked++;
    }
  });

  if (checked > 1) {
    return {
      requireOneCheckboxToBeChecked: true,
    };
  }
  return null;
};
