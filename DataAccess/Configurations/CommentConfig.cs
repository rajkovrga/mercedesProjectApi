using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataAccess.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasMany(x => x.CommentLikes)
                .WithOne(x => x.Comment)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
