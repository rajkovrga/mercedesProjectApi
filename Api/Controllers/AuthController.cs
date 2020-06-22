using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Application;
using Application.Commands;
using Application.Dto;
using Application.Queries;
using DataAccess;
using Implementation.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtManager manager;
        private readonly UseCaseExecutor _executor;
        public AuthController(UseCaseExecutor executor, JwtManager manager)
        {
            _executor = executor;
            this.manager = manager;
        }
        // GET: api/Auth
        [HttpGet]
        public IActionResult Get([FromServices] IGetAllUsersQuery query, [FromBody] SearchUserDto search)
        {
            var users = _executor.ExecuteQuery(query, search, "use-admin-panel");
            return Ok(users);
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            var user = _executor.ExecuteQuery(query, id);
            return Ok(user);
        }
        [HttpPost]
        [Route("/api/login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            var token = manager.CreateToken(request.Email, request.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpPost]
        [Route("/api/registration")]
        public IActionResult Registration([FromBody] UserDto request, [FromServices] IRegistrationCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }
  
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("/api/comment")]
        [Authorize]
        public IActionResult CreateComment([FromBody] CommentDto dto,[FromServices] ICommentCommand command)
        {
            _executor.ExecuteCommand(command, dto, "comments");
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        [Route("/api/comment/{id}")]
        [Authorize]
        public IActionResult UpdateComment(int id, [FromBody] CommentDto dto, [FromServices] IUpdateCommentCommand command)
        {
            _executor.ExecuteCommandWithId(command, dto, id, "comments");
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete]
        [Route("/api/comment/{id}")]
        [Authorize]
        public IActionResult DeleteComment(int id, [FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id, "comments");
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        [Route("/api/comment/like")]
        [Authorize]
        public IActionResult LikeComment([FromBody] CommentLikeDto dto, [FromServices] ILikeCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto, "likes");
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("/api/product/like")]
        [Authorize]
        public IActionResult Like([FromBody] ProductLikeDto dto, [FromServices] ILikeProductCommand command)
        {
            _executor.ExecuteCommand(command, dto, "likes");
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        [Route("/api/comment/dislike")]
        [Authorize]
        public IActionResult Dislike([FromBody] CommentLikeDto dto, [FromServices] IDislikeCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto, "likes");
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete]
        [Route("/api/product/dislike")]
        [Authorize]
        public IActionResult DislikeComment([FromBody] ProductLikeDto dto, [FromServices] IDislikeProductCommand command)
        {
            _executor.ExecuteCommand(command, dto, "likes");
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
