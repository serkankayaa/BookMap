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

  constructor(private categoryService: CategoryService, private toasterService: ToastrService) { }

  ngOnInit() {
    this.GetCategories();
  }
  GetCategories(): void {
    this.categoryService.getCategories().subscribe(data => this.allCategories = data);
  }

  postCategory(): object {
    const result = this.categoryService.postCategory(this.category).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toasterService.success('Category saved successfully.');
        this.GetCategories();
        this.category = new Category();
        return;
      }

      if (response.body === false) {
        this.toasterService.error('This category saved already!');
        return;
      }
    });
    return result;
  }
}
