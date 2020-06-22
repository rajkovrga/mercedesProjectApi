using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.Dto;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        public ProductController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get([FromBody] ProductSearchDto search, [FromServices] IGetAllProductQuery<ProductResult> query)
        {
            var products = executor.ExecuteQuery(query, search);
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get1")]
        public IActionResult Get(int id, [FromServices] IGetOneProductQuery query)
        {
            var product = executor.ExecuteQuery(query, id);
            return Ok(product);
        }

        [HttpGet]
        [Route("/api/products/top/{id}")]
        [Authorize]
        public IActionResult TopProducts(int id, [FromServices] ITopLikeProductsQuery query)
        {
            var product = executor.ExecuteQuery(query, id, "use-admin-panel");
            return Ok(product);
        }

        [HttpGet]
        [Route("/api/comments/top/{id}")]
        [Authorize]
        public IActionResult TopComments(int id,[FromServices] ITopLikeCommentsQuery query)
        {
            var comments = executor.ExecuteQuery(query, id, "use-admin-panel");
            return Ok(comments);
        }

        [HttpGet]
        [Route("/api/comments/product")]
        public IActionResult GetCommentsForProduct([FromServices] IGetProductCommentsQuery query, [FromBody] CommentSearchDto search)
        {
            var comments = executor.ExecuteQuery(query, search);
            return Ok(comments);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
            executor.ExecuteCommand(command,dto, "create-product");
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] ProductDto dto, [FromServices] IUpdateProductCommand command)
        {
            executor.ExecuteCommandWithId(command, dto, id, "update-product");
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            executor.ExecuteCommand(command, id, "delete-product");
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        [Route("/api/product/upload")]
        [Authorize]
        public IActionResult UploadPhoto([FromForm] ImageDto dto, [FromServices] IUploadProductPhotoCommand command)
        {
            executor.ExecuteCommand(command, dto, "create-product");
            return Ok("OK");
        }
    }
}
