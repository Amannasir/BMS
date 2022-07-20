using BMS.Data;
using BMS.Data.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BMS.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBookService _service;
        readonly IBookManager bookManager;
       
        public BooksController(IBookService service,
            IBookManager bookManager)     
        {
            this.bookManager = bookManager;
            _service = service;
        }
        //create/Add new Book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody]Book book)
        {
            try
            {
                if((book.Author != null) && (book.Title != null) && (book.Description != null))
                {
                    _service.AddBook(book);
                    return Ok(book);
                }
                return BadRequest("Book was not added");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //_service.AddBook(book);
            //return Ok();
        }
        //Read All Books
        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        //Update the Book

        [HttpPut("UpdateBook/{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            _service.UpdateBook(id, book);
            return Ok(book);
        }
        //Delete a Book 
        [HttpDelete("DeleteBook/{id}")]

        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }

        //Get a Single Book by id 
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }

        //getBook
        [HttpGet("{id}")]
        public async Task<MBook> GetByIdAsync([FromRoute] Guid id)
        {
            return await this.bookManager.GetByIdAsync(id);
        }

        //getAll data
        [HttpGet("getAll")]
        public async Task<List<MBook>>GetListAsync() => await this.bookManager.GetListAsync();

        // update re

        [HttpPut("updateReq")]
        public async Task UpdateAsync([FromBody] MBook book) => await this.bookManager.UpdateAsync(book);


        [HttpDelete("{id}")]
        public async Task Deleteasync([FromRoute] Guid id) => await this.bookManager.DeleteAsync(id);


        [HttpPost("AddNBook")]
        public async Task<MBook> CreateAsync([FromBody] MBook book)
        {
            
            return await this.bookManager.CreateAsync(book);
        }


    }
}
