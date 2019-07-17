import { AuthorService } from './../../services/author.service';
import { Author } from './../../models/author';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-admin-author',
  templateUrl: './admin-author.component.html',
  styleUrls: ['./admin-author.component.css']
})
export class AdminAuthorComponent implements OnInit {
  public authorForm: FormGroup;
  public author = new Author();
  public AuthorList: Author[];
  public formSubmitted = false;

  constructor(private fb: FormBuilder, private authorService: AuthorService) { }

  ngOnInit() {
    this.authorForm = this.fb.group({
      author: ['', Validators.required],
      birthDate: ['', Validators.required],
      biography: ['', Validators.required]
    });
    this.getAllAuthors();
  }

  get form() {
    return this.authorForm.controls;
  }

  getAllAuthors() {
    this.authorService.getAllAuthors().subscribe(data => {
      this.AuthorList = data;
    });
    console.log(this.AuthorList);
  }

  submitAuthor() {
    this.formSubmitted = true;
    if (this.authorForm.invalid) {
      return;
    }
  }
}
