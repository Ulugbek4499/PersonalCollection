using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Collections.Queries.GetCollection
{
    public record GetCollectionQuery(Guid Id) : IRequest<CollectionDto>;

    public class GetCollectionQueryHandler : IRequestHandler<GetCollectionQuery, CollectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCollectionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CollectionDto> Handle(GetCollectionQuery request, CancellationToken cancellationToken)
        {
            Collection maybeCollection = await
              _context.Collections.FindAsync(new object[] { request.Id });

            ValidateCollectionIsNotNull(request, maybeCollection);

            return _mapper.Map<CollectionDto>(maybeCollection);
        }

        private void ValidateCollectionIsNotNull(GetCollectionQuery request, Collection? maybeCollection)
        {
            if (maybeCollection is null)
            {
                throw new NotFoundException(nameof(Collection), request.Id);
            }
        }
    }
}
