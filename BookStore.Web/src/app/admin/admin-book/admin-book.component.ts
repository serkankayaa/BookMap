import { AuthorService } from './../../services/author.service';
import { ShopService } from './../../services/shop.service';
import { PublisherService } from './../../services/publisher.service';
import { CategoryService } from './../../services/category.service';
import { Category } from './../../models/category';
import { Author } from './../../models/author';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Book } from '../../models/book';
import { Publisher } from '../../models/publisher';
import { UploadCover } from '../../helper/Validations';
import { Shop } from '../../models/shop';
declare var $: any;

@Component({
  selector: 'app-admin-book',
  templateUrl: './admin-book.component.html',
  styleUrls: ['./admin-book.component.css']
})
export class AdminBookComponent implements OnInit {
  public formSubmitted = false;
  public book: object = new Book();
  public authorList: Author[];
  public categoryList: Category[];
  public publisherList: Publisher[];
  public shopList: Shop[];
  public uploadedCover;
  public bookForm: FormGroup;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private publisherService: PublisherService,
    private shopService: ShopService,
    private authorService: AuthorService) { }

  get form() {
    return this.bookForm.controls;
  }

  ngOnInit() {
    this.bookForm = this.fb.group({
      book: ['', Validators.required],
      summary: ['', Validators.required],
      author: ['', Validators.required],
      publisher: ['', Validators.required],
      category: ['', Validators.required],
      shop: ['', Validators.required],
      bookImage: ['', Validators.required]
    }, {
        validator: UploadCover('bookImage')
      });
    this.getServiceData();
    $('#bookModal').modal('show');
  }


  uploadCover(file) {
    this.uploadedCover = file[0]
    console.log(this.uploadedCover);
  }

  submitBook() {
    this.formSubmitted = true;
    if (this.bookForm.invalid) {
      return;
    }
    console.log(this.bookForm);
    console.log(this.book);
  }

  getServiceData() {
    this.categoryService.getAllCategories().subscribe(categoryData => {
      this.categoryList = categoryData;
    });
    this.shopService.getAllShops().subscribe(shopData => {
      this.shopList = shopData;
    });
    this.publisherService.getAllPublishers().subscribe(publisherData => {
      this.publisherList = publisherData;
    });
    this.authorService.getAllAuthors().subscribe(authorData => {
      this.authorList = authorData;
    });
  }
}
