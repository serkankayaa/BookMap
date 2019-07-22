import { DocumentService } from './../../services/document.service';
import { AuthorService } from './../../services/author.service';
import { Author } from './../../models/author';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NgbDateStruct, NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DateControl } from '../../helper/Validations';
declare var $: any;


@Component({
  selector: 'app-admin-author',
  templateUrl: './admin-author.component.html',
  styleUrls: ['./admin-author.component.css']
})
export class AdminAuthorComponent implements OnInit {
  public authorForm: FormGroup;
  public author = new Author();
  public authorList: Author[];
  public formData = new FormData();
  public dateModel: NgbDateStruct;
  public formSubmitted = false;
  public uploadedImage;

  constructor(private fb: FormBuilder,
    private authorService: AuthorService,
    private config: NgbDatepickerConfig,
    private toastr: ToastrService,
    private documentService: DocumentService) {

    // Customize default values of datepickers
    config.minDate = { year: 1900, month: 1, day: 1 };
    config.maxDate = { year: 2023, month: 12, day: 31 };
  }

  // TODO: Date Validaiton
  ngOnInit() {
    this.authorForm = this.fb.group({
      author: ['', Validators.required],
      birthDate: ['', Validators.required],
      biography: ['', Validators.required],
      authorImage: ['']
    }, {
        dateValidator: DateControl('birthDate')
      });
    this.getAllAuthors();
  }

  get form() {
    return this.authorForm.controls;
  }

  getAllAuthors() {
    this.authorService.getAllAuthors().subscribe(data => {
      this.authorList = data;
    });
  }

  uploadFile(file) {
    this.uploadedImage = file[0];
    this.formData.append('file', this.uploadedImage, this.uploadedImage.name);
    this.documentService.postDocument(this.formData).subscribe(res => {
      this.author.ImageIdFk = res.toString();
    });
  }

  submitAuthor() {
    this.formSubmitted = true;
    console.log(this.author);
    console.log(this.authorForm);
    if (this.authorForm.invalid) {
      return;
    }
    this.authorService.postAuthor(this.author).subscribe(res => {
      console.log("authorService");
      console.log(res);
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Shop '${this.author.AuthorName}' successfully added!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllAuthors();
        $('#authorModal').modal('hide');
      }
    });
  }
}
