﻿using BookApi.Models;
using BookApi.OpenApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [Consumes(contentType: ContentTypes.APPLICATION_JSON)]
    [Produces(contentType: ContentTypes.APPLICATION_JSON)]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get the list of all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return new Book[] { };
        }
    }
}
