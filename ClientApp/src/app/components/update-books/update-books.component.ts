

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { title } from 'process';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-update-books',
  templateUrl: './update-books.component.html',
  styleUrls: ['./update-books.component.css']
})
export class UpdateBooksComponent implements OnInit {
  book:Book;
  bookid:string = this.route.snapshot.params["id"];
  updateBookForm :FormGroup;
  _baseURL : string = "api/Books";
  constructor(private service: BookService,
    private route:ActivatedRoute,
    private router: Router,
    private fb : FormBuilder,
    private http: HttpClient ) { }

  ngOnInit() {
    this.updateBookForm = this.fb.group({
      id:[null, []],
      title:[null, []],
      author:[null, []],
      description:[null,Validators.compose([Validators.required,Validators.minLength(30)])],
      rate:[null, []],
      dateStart:[null, []],
      dateRead:[null, []]     
    });

    this.http.get<Book>(this._baseURL+"/"+this.bookid).subscribe(data =>{
      debugger;
      this.updateBookForm.patchValue(data);    
    })
  }
  onSubmit(){
    this.updateBookForm.value.id = this.bookid;
    this.http.put<Book>(this._baseURL+"/updateReq",this.updateBookForm.value).subscribe(data =>{
      debugger;
        this.router.navigate(["/books"]);        
      });
  }
}
