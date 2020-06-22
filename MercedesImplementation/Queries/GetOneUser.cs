using Application.Dto;
using Application.Exceptions;
using Application.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries
{
    public class GetOneUser : IGetOneUserQuery
    {
        private readonly DataContext _context;
        public GetOneUser(DataContext context)
        {
            _context = context;
        }

        public string Name => "Get one user";

        public UserResultDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            if(user == null)
            {
                throw new ModelNotFound();
            }

            return new UserResultDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
