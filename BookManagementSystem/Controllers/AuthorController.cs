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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService service;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> Get()
        {
            try
            {
                var authors = await this.service.GetAllAuthorAsync();
                var allAuthorsViewModel = this.mapper.Map<List<AuthorViewModel>>(authors);

                return allAuthorsViewModel;
            }
            catch (AuthorException ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Get(int id)
        {
            try
            {
                var currentAuthor = await this.service.GetAuthorByIdAsync(id);
                var resultAuthor = this.mapper.Map<AuthorViewModel>(currentAuthor);
                return resultAuthor;
            }
            catch (AuthorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorViewModel viewModel)
        {
            try
            {
                var newAuthor = this.mapper.Map<AuthorDto>(viewModel);
                await this.service.AddAuthorAsync(newAuthor);

                return Ok();
            }
            catch (AuthorException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Put(int id, [FromBody] AuthorViewModel viewModel)
        {
            try
            {
                var newAuthor = this.mapper.Map<AuthorDto>(viewModel);
                var updatedAuthor = await this.service.UpdateAuthorAsync(id, newAuthor);
                var resultAuthor = this.mapper.Map<AuthorViewModel>(updatedAuthor);

                return resultAuthor;
            }
            catch (AuthorException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
               var resultFromAuthorDeleted = await this.service.RemoveAuthorAsync(id);
                return resultFromAuthorDeleted;
            }
            catch (AuthorException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
