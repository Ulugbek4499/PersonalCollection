using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand:IRequest<CommentDto>
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public Guid ItemId { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment maybeComment = await
                _context.Comments.FindAsync(new object[] { request.Id });

            Item maybeItem =
                _context.Items.SingleOrDefault(p => p.Id.Equals(request.ItemId));

            maybeComment.Content = request.Content;
            maybeComment.Item = maybeItem;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CommentDto>(maybeComment);

            throw new NotImplementedException();
        }
    }
}
