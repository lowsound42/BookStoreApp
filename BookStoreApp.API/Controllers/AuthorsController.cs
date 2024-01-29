using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;
using BookStoreApp.API.Static;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(BookStoreDbContext context, IMapper mapper, ILogger<AuthorsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
            _logger.LogInformation($"Requst to {nameof(GetAuthors)}");
            try
            {
                var authorDtos = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(await _context.Authors.ToArrayAsync());
                return Ok(authorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthors)})");
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadOnlyDto>> GetAuthor(int id)
        {

            try
            {
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    return NotFound();
                }

                var authorDto = _mapper.Map<AuthorReadOnlyDto>(author);

                return authorDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthor)})");
                return StatusCode(500, Messages.Error500Message);
            }
          
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto)
        {
            try
            {
                if (id != authorDto.Id)
                {
                    return BadRequest();
                }
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    return NotFound();
                }

                _mapper.Map(authorDto, author);
                _context.Entry(author).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AuthorExists(id))
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(PutAuthor)})");
                return StatusCode(500, Messages.Error500Message);
            }
           
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDTO>> PostAuthor(AuthorCreateDTO authorDto)
        {
            try
            {
                var author = _mapper.Map<Author>(authorDto);
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAuthor", new { id = author.Id }, author);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(PostAuthor)})");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(DeleteAuthor)})");
                return StatusCode(500, Messages.Error500Message);
            }
         
        }

        private Task<bool> AuthorExists(int id)
        {
            return _context.Authors.AnyAsync(e => e.Id == id);
        }
    }
}
