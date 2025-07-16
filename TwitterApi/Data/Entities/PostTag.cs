using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterApi.Data.Entities
{
    public class PostTag
    {
        public long Id { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public long PostId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public long TagId { get; set; }
    }
}
