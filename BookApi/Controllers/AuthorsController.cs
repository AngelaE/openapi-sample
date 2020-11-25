using BookApi.Models;
using BookApi.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(contentType: ContentTypes.APPLICATION_JSON)]
    [Produces(contentType: ContentTypes.APPLICATION_JSON)]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private List<Author> _authors = new() { 
        new Author { Id = 1, Name = "Roald Dahl"},
        new Author { Id = 2, Name = "Terry Pratchet"}
        };

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GetAll")]
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors.ToArray();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Author Get(int id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Author), 200)]
        public Author AddAuthor([FromBody]Author author)
        {
            _authors.Add(author);
            return author;
        }
    }
}
