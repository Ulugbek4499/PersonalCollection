using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Comments.Commands.CreateCommand
{
    public class CreateCommentCommand:IRequest<CommentDto>
    {
        public string? Content { get; set; }
        public Guid ItemId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Item maybeItem =
               _context.Items.SingleOrDefault(p => p.Id.Equals(request.ItemId));

            ValidateItemIsNotNull(request, maybeItem);

            var comment = new Comment()
            {
                Content = request.Content,
                Item = maybeItem
            };

            comment = _context.Comments.Add(comment).Entity;
            await _context.SaveChangesAsync(cancellationToken);\
            
            return _mapper.Map<CommentDto>(comment);
        }

        private void ValidateItemIsNotNull(CreateCommentCommand request, Item? maybeItem)
        {
            if (maybeItem == null)
            {
                throw new NotFoundException(nameof(Item), request.ItemId);
            }
        }
    }
}
