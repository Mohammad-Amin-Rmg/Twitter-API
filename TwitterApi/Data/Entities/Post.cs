using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Data.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedAt { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<View> Views { get; set; }

    }

    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(e => e.Content).HasMaxLength(500);
            builder.Property(e => e.Content).IsRequired();
        }
    }
}
