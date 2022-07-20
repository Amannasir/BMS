
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  public books:Book[];

  constructor( private service: BookService, private router: Router, private http: HttpClient) { }

  ngOnInit() {

  // this.service.getAllBooks().subscribe((data): void => {
  //   this.books = data;
  // })
  this.http.get<Book[]>("api/Books"+"/getAll").subscribe((data): void => {
    this.books = data;
  })

  // this.http.get<Book[]>("api/Books"+"/AddNBook").subscribe((data): void => {
  //      this.books = data;
  // })

  //https://docs.microsoft.com/en-us/learn/paths/get-started-cds/
}
  // AddBook(){
  //   this.router.navigate(["/new-book/"]);
  // }

  showBook(id: number){
    this.router.navigate(["/show-book/"+id]);
  }
  updateBook(id: number){
    this.router.navigate(["/update-book/"+id]);
  }
  deleteBook(id: number){
    this.router.navigate(["/delete-book/"+id]);
  }
}
