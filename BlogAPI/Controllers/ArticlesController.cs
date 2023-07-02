using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BlogAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesAPIDbContext dbContext;

        public ArticlesController(ArticlesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            return Ok(await dbContext.Articles.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetArticle([FromRoute] Guid id)
        {
            var article = await dbContext.Articles.FindAsync(id);

            if(article == null)
            {
                return NotFound();  
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleRequest addContactRequest)
        {
            var article = new Article()
            {
                Id = Guid.NewGuid(),
                Title = addContactRequest.Title,
                Content = addContactRequest.Content,
                Date = addContactRequest.Date,
                Author = addContactRequest.Author,
            };

            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();

            return Ok(article);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] Guid id, UpdateArticleRequest updateArticleRequest)
        {
            var  article = await dbContext.Articles.FindAsync(id);

            if(article != null)
            {
                article.Title = updateArticleRequest.Title;
                article.Content = updateArticleRequest.Content;
                article.Date = updateArticleRequest.Date;
                article.Author = updateArticleRequest.Author;

                await dbContext.SaveChangesAsync();

                return Ok(article); 
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] Guid id)
        {
            var article = await dbContext.Articles.FindAsync(id);

            if (article != null)
            {
                dbContext.Remove(article);  
                await dbContext.SaveChangesAsync();
                return Ok(article);
            }

            return NotFound(); 

        }

    }
}
