using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesDomen.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
