using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class UserResultDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
