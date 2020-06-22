using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domen.Entities
{
    public class CommentLike
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
