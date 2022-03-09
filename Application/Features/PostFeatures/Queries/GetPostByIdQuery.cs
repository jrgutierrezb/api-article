using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public long Id { get; set; }
        public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
        {
            private readonly IApplicationDbContext _context;
            public GetPostByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Post> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
            {
                var post = _context.Posts.FirstOrDefault(a => a.Id == query.Id);
                if (post == null) return null;
                return post;
            }
        }
    }
}
