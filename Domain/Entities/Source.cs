using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Source : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
