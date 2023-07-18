using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Comments.Commands.DeleteCommand
{
    public record DeleteCommentCommand(Guid commentId) : IRequest<CommentDto>;

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Comment maybeComment = await
                  _context.Comments.FindAsync(new object[] { request.commentId });

            ValidateCommentIsNotNull(request, maybeComment);

            _context.Comments.Remove(maybeComment);

            await _context.SaveChangesAsync(cancellationToken);


            return _mapper.Map<CommentDto>(maybeComment);
        }

        private static void ValidateCommentIsNotNull(DeleteCommentCommand request, Comment maybeComment)
        {
            if (maybeComment is null)
            {
                throw new NotFoundException(nameof(Comment), request.commentId);
            }
        }
    }
}
