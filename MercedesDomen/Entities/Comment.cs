using System;
using System.Collections.Generic;
using System.Text;

namespace Domen.Entities
{
    public class Comment : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string CommentText { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();
    }
}
