import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-show-books',
  templateUrl: './show-books.component.html',
  styleUrls: ['./show-books.component.css']
})
export class ShowBooksComponent implements OnInit {
  book:Book;
  _baseURL : string = "api/Books";
  bookid: string = this.route.snapshot.params["id"];
  constructor(private service: BookService, 
    private route: ActivatedRoute,
    private http: HttpClient) { }

  ngOnInit() {
    // this.service.getBookById(this.route.snapshot.params.id).subscribe(data =>{
    //   this.book = data;
    // });
    this.http.get<Book>(this._baseURL+"/"+ this.bookid).subscribe(data =>{
      this.book = data;
    });
  }

}
