using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalComment.Application.UseCases.Comments.Queries.GetComment
{
    public record GetCommentQuery(Guid Id) : IRequest<CommentDto>;

    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            Comment maybeComment = await
              _context.Comments.FindAsync(new object[] { request.Id });

            ValidateCommentIsNotNull(request, maybeComment);

            return _mapper.Map<CommentDto>(maybeComment);
        }

        private void ValidateCommentIsNotNull(GetCommentQuery request, Comment? maybeComment)
        {
            if (maybeComment is null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }
        }
    }
}
