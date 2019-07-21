import { FormGroup } from '@angular/forms';

export function UploadCover(controlName: string) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    if (control.value == "") {
      control.setErrors({ uploadCover: true });
    } else {
      control.setErrors({ uploadCover: false });
    }
  }
}

export function DateControl(controlName: string) {
  let ptDatePattern = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/g;
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    if (control.value.match(ptDatePattern)) {
      control.setErrors({ dateInput: true });
    } else {
      control.setErrors({ dateInput: false });
    }
  }
}
