import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  _baseURL : string = "api/Books";

  constructor(private http: HttpClient) { }

    getAllBooks(){
      return this.http.get<Book[]>(this._baseURL+"/GetAll");
    }

    addBook(book: Book){
      return this.http.post(this._baseURL+"/AddNBook/", book);
    }

    getBookById(id: number){
      return this.http.get<Book>(this._baseURL+"/SingleBook/"+id);
    }

    updateBook(book: Book){
      return this.http.put(this._baseURL+"/updateReq/", book);
    }

    deleteBook(id: number){
      return this.http.delete(this._baseURL+"/"+id);
    }
}


