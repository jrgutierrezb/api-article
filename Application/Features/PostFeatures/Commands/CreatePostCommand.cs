using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands
{
    public class CreatePostCommand : IRequest<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public DateTime PublishedAt { get; set; }
        public long SourceId { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public CreatePostCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreatePostCommand command, CancellationToken cancellationToken)
            {
                var post = new Post
                {
                    Title = command.Title,
                    Content = command.Content,
                    Description = command.Description,
                    Url = command.Url,
                    Image = command.Image,
                    PublishedAt = command.PublishedAt,
                    SourceId = command.SourceId
                };
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post.Id;
            }
        }
    }
}
