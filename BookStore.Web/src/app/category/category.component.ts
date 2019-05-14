import { Component, OnInit } from '@angular/core';

import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  category = new Category();
  allCategories: Category[];
  isEdit: boolean;

  constructor(private categoryService: CategoryService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.GetCategories();
  }

  refreshForm(): void {
    const dirtyFormID = 'categoryForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  editCategory(selectedCategory: Category): void {
    this.category = selectedCategory;
    this.isEdit = true;
  }


  GetCategories(): void {
    this.categoryService.getCategories().subscribe(data => this.allCategories = data);
  }

  postCategory(): object {
    const result = this.categoryService.postCategory(this.category).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Category saved successfully.');
        this.GetCategories();
        this.refreshForm();
        this.category = new Category();
        return;
      }

      if (response.body === false) {
        this.toastrService.error('This category saved already!');
        return;
      }
    });

    return result;
  }

  updateCategory(): void {
    const result = this.categoryService.updateCategory(this.category).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Category edited successfully.');
          this.GetCategories();
          this.refreshForm();
          this.category = new Category();
          this.isEdit = false;
        }
        if (res.body === false) {
          this.toastrService.error('Please make a change to edit.');
          this.focusErrorInput();
          return;
        }
      });
  }

  focusErrorInput() {
    const dirtyFormID = 'categoryName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  deleteCategory(id: any): void {
    this.categoryService.deleteCategory(id).subscribe((res) => {
      {
        this.toastrService.success('Category deleted successfully.');
        this.GetCategories();
        this.refreshForm();
        this.category = new Category();
        this.isEdit = false;
      }
    });
  }
}
