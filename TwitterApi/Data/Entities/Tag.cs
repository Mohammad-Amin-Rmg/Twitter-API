using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TwitterApi.Data.Entities
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }

    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}