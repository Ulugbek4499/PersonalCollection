using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalComment.Application.UseCases.Comments.Queries.GetComments
{

    public record GetCommentsQuery : IRequest<CommentDto[]>;

    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, CommentDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto[]> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            Comment[] Comments = await _context.Comments.ToArrayAsync();

            return _mapper.Map<CommentDto[]>(Comments);
        }
    }
}
