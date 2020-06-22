using Application.Dto;
using Application.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetAllUsers : IGetAllUsersQuery
    {
        private readonly DataContext _context;

        public GetAllUsers(DataContext context)
        {
            _context = context;
        }

        public string Name => "Get all users";

        public ResultPaginationDto<UserResultDto> Execute(SearchUserDto search)
        {
            var users = _context.Users.AsQueryable();

            if(!string.IsNullOrEmpty(search.SearchText) || !string.IsNullOrWhiteSpace(search.SearchText))
            {
                users = users.Where(x => x.Email.ToLower().Contains(search.SearchText.ToLower())
                || x.Username.ToLower().Contains(search.SearchText.ToLower()));
            }

            var countItems = users.Count();

            var result = new ResultPaginationDto<UserResultDto>
            {
                Items = users.Skip(search.PerPage * (search.Page - 1)).Take(search.PerPage)
                        .Select(x => new UserResultDto
                        { 
                            Id = x.Id,
                            Username = x.Username,
                            Email = x.Email,
                            CreatedAt = x.CreatedAt
                        }).ToList(),
                PerPage = search.PerPage,
                CurrentPage = search.Page,
                CountItems = countItems
            };


            return result;
        }
    }
}
