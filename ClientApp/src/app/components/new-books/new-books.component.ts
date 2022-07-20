import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { createFalse } from 'typescript';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-books',
  templateUrl: './new-books.component.html',
  styleUrls: ['./new-books.component.css']
})
export class NewBooksComponent implements OnInit {
  _baseURL : string = "api/Books";
  addBookForm:FormGroup;
  showError : boolean = false;
  book:Book;

  constructor(private service:BookService, private fb: FormBuilder, private router: Router,  private http: HttpClient) { }

  ngOnInit() {
    this.addBookForm = this.fb.group({
      id:[],
      title:[null,Validators.required],
      author:[null,Validators.required],
      description:[null,Validators.compose([Validators.required,Validators.minLength(30)])],
      rate:[null],
      dateStart:[null],
      dateRead:[null],
    })
  }
 
  onSubmit(){

    // this.service.addBook(this.addBookForm.value).subscribe(data =>{
    //   this.router.navigate(["/books"]);
    // }, error => {
    //   this.showError = true;
    // })
debugger;
    this.http.post<Book>(this._baseURL+"/AddNBook",this.addBookForm.value).subscribe(data =>{
     this.router.navigate(["/books"]);
    });
}
}
