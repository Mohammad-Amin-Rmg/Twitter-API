using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterApi.Data.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public long PostId { get; set; }
    }

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Content).HasMaxLength(250);
            builder.Property(e => e.Content).IsRequired();
        }
    }
}