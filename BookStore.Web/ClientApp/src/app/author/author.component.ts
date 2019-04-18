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
  allAuthor : Author[];
  response : object;
   
  constructor(private authorService : AuthorService, private toasterService : ToastrService) { }

  ngOnInit() {
    this.getAuthor();
  }

  postAuthor(): object {
    const result = this.authorService.postAuthor(this.author).subscribe((response) => {
      if(response.body != null && response.ok && response.body != false){
        this.toasterService.success("Author saved successfully");
        this.getAuthor();
        this.author = new Author();
        
        return;
      }

      if(response.body == false){
        this.toasterService.error("This author saved already");
        return;
      }
    });
    
    return result;
  };

  getAuthor(): void {
    this.authorService.getAllAuthor()
        .subscribe(data=> this.allAuthor = data);
  }

}
