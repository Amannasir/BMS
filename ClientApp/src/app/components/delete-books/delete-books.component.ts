import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-delete-books',
  templateUrl: './delete-books.component.html',
  styleUrls: ['./delete-books.component.css']
})
export class DeleteBooksComponent implements OnInit {
  book:any;

  _baseURL : string = "api/Books";
  bookid: string = this.route.snapshot.params["id"];
  constructor(private route: ActivatedRoute,
    private router: Router,
    private service: BookService,
    private http: HttpClient
    ) { }

  ngOnInit() {
    // this.service.getBookById(this.route.snapshot.params.id).subscribe(data =>{
    //   this.book = data;
    // })
    this.http.get<Book>(this._baseURL+"/"+ this.bookid).subscribe(data =>{
      this.book = data;
    });
  }

  deleteBook(id: number){
    this.http.delete<Book>(this._baseURL+"/"+ this.bookid).subscribe(data =>{
      this.router.navigate(["/books"]);
    })
  }
}
