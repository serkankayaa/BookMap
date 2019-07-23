import { CategoryService } from './../../services/category.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Category } from './../../models/category';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css']
})
export class AdminCategoryComponent implements OnInit {
  public formSubmitted = false;
  public category = new Category();
  public editCategory = {};
  public deleteCategory = {};
  public categoryList: Category[];
  public addCategoryForm: FormGroup;
  public editCategoryForm: FormGroup;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.addCategoryForm = this.fb.group({
      category: ['', Validators.required],
    });
    this.editCategoryForm = this.fb.group({
      category: ['', Validators.required],
    });
    this.getAllCategories();
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(categoryData => {
      this.categoryList = categoryData;
    });
  }

  submitCategory() {
    this.formSubmitted = true;
    if (this.addCategoryForm.invalid) {
      this.toastr.error(`Grrr! Please fill required fields!`, '', {
        closeButton: true,
        progressBar: true,
        progressAnimation: 'decreasing',
        timeOut: 4000
      });
      return;
    }

    this.categoryService.postCategory(this.category).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Category '${this.category.CategoryName}' successfully added!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.category = new Category();
        this.formSubmitted = false;
        this.getAllCategories();
        $('#categoryModal').modal('hide');
      }
    });
    console.log(this.category);
  }

  editModal(category) {
    this.editCategory = { ...category };
    $('#editCategoryModal').modal('show');
  }

  // Updates the selected shop data
  updateCategory(SelectedCategory) {
    this.formSubmitted = true;
    if (this.editCategoryForm.invalid) {
      this.toastr.error(`Grrr! Please fill required fields!`, '', {
        closeButton: true,
        progressBar: true,
        progressAnimation: 'decreasing',
        timeOut: 4000
      });
      return;
    }

    this.categoryService.updateCategory(SelectedCategory).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Category '${SelectedCategory.CategoryName}' successfully updated!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllCategories();
        $('#editCategoryModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#editCategoryModal').modal('hide');
      }
    });
  }

  // Passes selected category data and opens delete modal
  deleteModal(category) {
    this.deleteCategory = { ...category };
    $('#deleteCategoryModal').modal('show');
  }

  // Deletes the selected category data
  deleteExistingCategory(SelectedCategory) {
    this.categoryService.deleteCategory(SelectedCategory.CategoryId).subscribe(res => {
      if (res) {
        this.toastr.success(`Category '${SelectedCategory.CategoryName}' successfully deleted!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllCategories();
        $('#deleteCategoryModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#deleteCategoryModal').modal('hide');
      }
    });
  }

  get form() {
    return this.addCategoryForm.controls;
  }

  get editForm() {
    return this.editCategoryForm.controls;
  }
}
