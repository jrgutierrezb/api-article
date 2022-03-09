using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public DateTime PublishedAt { get; set; }
        public long SourceId { get; set; }
        public Source Source { get; set; }

    }
}
