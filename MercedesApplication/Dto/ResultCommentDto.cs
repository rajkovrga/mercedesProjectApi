using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ResultCommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int CountLikes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }

    }
}
