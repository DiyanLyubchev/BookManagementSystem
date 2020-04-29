using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookManagementSystem.Models;
using BookManagementSystem.Service.Contracts;
using BookManagementSystem.Service.CustomException;
using BookManagementSystem.Service.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        private readonly IMapper mapper;

        public BookController(IBookService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> Get()
        {
            try
            {
                var allbooks = await this.service.GetAllBooksAsync();

                var resultBooks = this.mapper.Map<List<BookViewModel>>(allbooks);

                return resultBooks;
            }
            catch (BookException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> Get(int id)
        {
            try
            {
                var currentBook = await this.service.FindBookByIdAsync(id);
                var resultBook = this.mapper.Map<BookViewModel>(currentBook);
                return resultBook;
            }
            catch (BookException ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookViewModel viewModel)
        {
            try
            {
                var newBook = this.mapper.Map<BookDto>(viewModel);
                await this.service.AddBookAsync(newBook);
                return Ok();
            }
            catch (BookException ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BookViewModel>> Put(int id, [FromBody] BookViewModel viewModel)
        {
            try
            {
                var currentBook = this.mapper.Map<BookDto>(viewModel);
                var updatedBook = await this.service.UpdateBookAsync(id, currentBook);
                var resultFromUpdatedBook = this.mapper.Map<BookViewModel>(updatedBook);

                return resultFromUpdatedBook;
            }
            catch (BookException ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var resultFromDeletedBook = await this.service.RemoveBookAsync(id);
                return resultFromDeletedBook;
            }
            catch (BookException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
