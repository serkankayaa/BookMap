import { Component, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { CategoryService } from '../../services/category.service';

import { Category } from '../../models/category';
declare var $: any;

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {

  category = new Category();
  allCategories: Category[];
  isEdit: boolean;
  categoryId: any;
  hasData = true;

  constructor(private categoryService: CategoryService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAllCategories();
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

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe(data => {
      if (data.length === 0) {
        this.hasData = false;
      } else {
        this.hasData = true;
        this.allCategories = data;
      }
    });
  }

  postCategory(): object {
    const postedCategory = this.categoryService.postCategory(this.category).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Category saved successfully.');
        this.getAllCategories();
        this.refreshForm();
        this.category = new Category();
        return;
      }

      if (response.body === false) {
        this.toastrService.error('This category saved already!');
        return;
      }
    });

    return postedCategory;
  }

  updateCategory(): void {
    this.categoryService.updateCategory(this.category).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Category edited successfully.');
          this.getAllCategories();
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

  deleteCategory(): void {
    this.categoryService.deleteCategory(this.categoryId).subscribe((res) => {
      {
        this.toastrService.success('Category deleted successfully.');
        this.getAllCategories();
        this.refreshForm();
        this.category = new Category();
        this.isEdit = false;
        $('#deleteCategory').modal('hide');
      }
    });
  }

  onDelete(id: any): void {
    $('#deleteCategory').modal('show');
    this.categoryId = id;
  }

  cancelUpdate() {
    this.category = new Category();
    this.isEdit = false;
    this.getAllCategories();
    this.refreshForm();
  }
}
