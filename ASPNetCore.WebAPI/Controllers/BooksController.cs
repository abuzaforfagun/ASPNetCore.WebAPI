﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCore.WebAPI.Core.Models;
using ASPNetCore.WebAPI.Presistance;
using AutoMapper;

namespace ASPNetCore.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private List<AuthorBook> ConvertKeyValuePresistanceToAuthor(List<KeyValuePresistance> authors, Book book){
            List<AuthorBook> authorBookList = new List<AuthorBook>();
            foreach(var a in authors){
                var author = Mapper.Map<Author>(a);
                AuthorBook authorBook = new AuthorBook(){
                    Author = author,
                    Book = book
                };
                authorBookList.Add(authorBook);
            }
            return authorBookList;
        }

        private List<KeyValuePresistance> ConvertnAuthorToKeyValuePresistance(List<AuthorBook> authors)
        {
            List<KeyValuePresistance> keyValuePresistanceList = new List<KeyValuePresistance>();
            foreach(var ab in authors){
                var author = Mapper.Map<Author, KeyValuePresistance>(ab.Author);
                keyValuePresistanceList.Add(author);
            }
            return keyValuePresistanceList;
        }

        
        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] BookPresistance bookPresistance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = Mapper.Map<BookPresistance, Book>(bookPresistance);
            book.AuthorsLink=ConvertKeyValuePresistanceToAuthor(bookPresistance.Authors, book);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            bookPresistance = Mapper.Map<Book, BookPresistance>(book);
            bookPresistance.Authors = ConvertnAuthorToKeyValuePresistance(book.AuthorsLink);
            return Ok(bookPresistance);
        }
        
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}