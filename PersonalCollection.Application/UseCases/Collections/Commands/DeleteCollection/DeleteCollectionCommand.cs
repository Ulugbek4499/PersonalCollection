using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Collections.Commands.DeleteCollection
{
    public record DeleteCollectionCommand(Guid collectionId) : IRequest<CollectionDto>;

    public class DeleteCollectionCommandHandler : IRequestHandler<DeleteCollectionCommand, CollectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper; 
        private readonly ICurrentUserService _currentUserService;

        public DeleteCollectionCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CollectionDto> Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
        {

            Collection maybeCollection = await _context.Collections.FindAsync(new object[] { request.collectionId });

            ValidateDepartmentIsNotNull(request, maybeCollection);

            // Check if the CreatedBy field of the collection matches the Id of the current user
            if (maybeCollection.CreatedBy != _currentUserService.Id)
            {
                throw new UnauthorizedException("User could not delete this collection.");
            }

            _context.Collections.Remove(maybeCollection);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CollectionDto>(maybeCollection);
        }

        private static void ValidateDepartmentIsNotNull(DeleteCollectionCommand request, Collection maybeCollection)
        {
            if (maybeCollection is null)
            {
                throw new NotFoundException(nameof(Collection), request.collectionId);
            }
        }
    }
}
