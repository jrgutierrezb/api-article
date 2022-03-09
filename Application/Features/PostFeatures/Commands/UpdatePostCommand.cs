using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands
{
    public class UpdatePostCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public DateTime PublishedAt { get; set; }
        public long SourceId { get; set; }
        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePostCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
            {
                var post = _context.Posts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (post == null)
                {
                    return default;
                }
                else
                {
                    post.Title = command.Title;
                    post.Content = command.Content;
                    post.Description = command.Description;
                    post.Url = command.Url;
                    post.Image = command.Image;
                    post.PublishedAt = command.PublishedAt;
                    post.SourceId = command.SourceId;
                    await _context.SaveChangesAsync();
                    return post.Id;
                }
            }
        }
    }
}
