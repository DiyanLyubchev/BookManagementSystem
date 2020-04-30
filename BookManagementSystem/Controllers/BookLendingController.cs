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
    public class BookLendingController : ControllerBase
    {
        private readonly IBookLendingService service;
        private readonly IMapper mapper;

        public BookLendingController(IBookLendingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookLendingViewModel>>> Get()
        {
            try
            {
                var booksLend = await this.service.GetAllBookLandingsAsync();
                var allBookLend = this.mapper.Map<List<BookLendingViewModel>>(booksLend);

                return allBookLend;
            }
            catch (BookLandingException ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<AuthorViewModel>> Get(int id)
        //{
        //    try
        //    {
        //        var currentAuthor = await this.service.GetAuthorByIdAsync(id);
        //        var resultAuthor = this.mapper.Map<AuthorViewModel>(currentAuthor);
        //        return resultAuthor;
        //    }
        //    catch (UserAccountException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookLendingViewModel viewModel)
        {
            try
            {
                var newUser = this.mapper.Map<BookLendingDto>(viewModel);
                await this.service.AddBookLandingAsync(newUser);

                return Ok();
            }
            catch (BookLandingException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    //    [HttpPut("{id}")]
    //    public async Task<ActionResult<AuthorViewModel>> Put(int id, [FromBody] AuthorViewModel viewModel)
    //    {
    //        try
    //        {
    //            var newAuthor = this.mapper.Map<AuthorDto>(viewModel);
    //            var updatedAuthor = await this.service.UpdateAuthorAsync(id, newAuthor);
    //            var resultAuthor = this.mapper.Map<AuthorViewModel>(updatedAuthor);

    //            return resultAuthor;
    //        }
    //        catch (UserAccountException ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }


    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<string>> Delete(int id)
    //    {
    //        try
    //        {
    //           var resultFromAuthorDeleted = await this.service.RemoveAuthorAsync(id);
    //            return resultFromAuthorDeleted;
    //        }
    //        catch (UserAccountException ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
    }
}
