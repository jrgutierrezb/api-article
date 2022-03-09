using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries
{
    public class GetAllPostsQuery : IRequest<IEnumerable<Post>>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<Post>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPostsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
            {
                var postList = await _context.Posts.Include(x => x.Source).ToListAsync();
                if (postList == null)
                {
                    return null;
                }
                return postList.AsReadOnly();
            }
        }
    }
}
