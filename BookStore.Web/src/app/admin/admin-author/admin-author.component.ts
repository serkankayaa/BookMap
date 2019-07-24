import { DocumentService } from './../../services/document.service';
import { AuthorService } from './../../services/author.service';
import { Author } from './../../models/author';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NgbDateParserFormatter, NgbDateStruct, NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
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
  public deleteAuthor = {};
  public formData = new FormData();
  public authorBirthDate: NgbDateStruct;
  public formSubmitted = false;
  public uploadedImage;
  public imagePath = 'assets/documents/';

  constructor(private fb: FormBuilder,
    private authorService: AuthorService,
    private config: NgbDatepickerConfig,
    private toastr: ToastrService,
    private documentService: DocumentService,
    private dateParse: NgbDateParserFormatter) {

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
    var dateTime = this.dateParse.format(this.authorBirthDate);
    var lastDate = new Date(dateTime);
    this.author.BirthDate = lastDate;

    if (this.authorForm.invalid) {
      return;
    }

    this.authorService.postAuthor(this.author).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Author '${this.author.AuthorName}' successfully added!`, '', {
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

  // Passes selected author data and opens delete modal
  deleteModal(author) {
    this.deleteAuthor = { ...author };
    $('#deleteAuthorModal').modal('show');
  }

  // Deletes the selected author data
  deleteExistingAuthor(SelectedAuthor) {
    this.authorService.deleteAuthor(SelectedAuthor.AuthorId).subscribe(res => {
      if (res) {
        this.toastr.success(`Author '${SelectedAuthor.AuthorName}' successfully deleted!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllAuthors();
        $('#deleteAuthorModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#deleteAuthorModal').modal('hide');
      }
    });
  }
}