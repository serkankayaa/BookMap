import { Component, OnInit } from '@angular/core';

import { Author } from '../models/author';
import { AuthorService } from '../services/author.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  author = new Author();
  allAuthor: Author[];
  response: object;
  isEdit = false;

  constructor(private authorService: AuthorService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAuthor();
  }

  refreshForm(): void {
    const dirtyFormID = 'authorForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  postAuthor(): object {
    const result = this.authorService.postAuthor(this.author).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Author saved successfully');
        this.author = new Author();
        this.getAuthor();
        this.refreshForm();

        return;
      }

      if (response.body === false) {
        this.toastrService.error('This author saved already');
        this.focusErrorInput();
        return;
      }
    });

    return result;
  }

  getAuthor(): void {
    this.authorService.getAllAuthor()
      .subscribe(data => this.allAuthor = data);
  }

  editAuthor(selectedAuthor: Author): void {
    this.author = selectedAuthor;
    console.log(this.author);
    this.isEdit = true;
  }

  updateAuthor(): void {
    const result = this.authorService.updateAuthor(this.author).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Author edited successfully.');
          this.getAuthor();
          this.refreshForm();
          this.author = new Author();
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
    const dirtyFormID = 'authorName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  deleteAuthor(id: any): void {
    this.authorService.deleteAuthor(id).subscribe((res) => {
      {
        this.toastrService.success('Author deleted successfully.');
        this.getAuthor();
        this.refreshForm();
        this.author = new Author();
        this.isEdit = false;
      }
    });
  }

}
