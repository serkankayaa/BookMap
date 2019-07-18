import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Category } from './../../models/category';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css']
})
export class AdminCategoryComponent implements OnInit {
  public formSubmitted = false;
  public category = new Category();
  public Categories: Category[];
  public categoryForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.categoryForm = this.fb.group({
      category: ['', Validators.required],
      categoryType: ['']
    });
  }

  get form() {
    return this.categoryForm.controls;
  }

  submitCategory() {
    this.formSubmitted = true;
    if (this.categoryForm.invalid) {
      return;
    }
    console.log(this.category);
  }
}
