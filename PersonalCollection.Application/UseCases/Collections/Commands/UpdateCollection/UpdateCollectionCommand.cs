using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Domain.States;

namespace PersonalCollection.Application.UseCases.Collections.Commands.UpdateCollection
{
    public class UpdateCollectionCommand:IRequest<CollectionDto>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TopicType? Topic { get; set; }
    }

    public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand, CollectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCollectionCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = userService;
        }

        public async Task<CollectionDto> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
        {
            Collection maybeCollection = await
                 _context.Collections.FindAsync(new object[] { request.Id });

            if (maybeCollection.CreatedBy != _currentUserService.Id)
            {
                throw new UnauthorizedException("User could not update this collection.");
            }

            ValidateCollectionIsNotNull(request, maybeCollection);

            maybeCollection.Name = request.Name;
            maybeCollection.Description= request.Description;
            maybeCollection.Image = request.Image;
            maybeCollection.Topic = request.Topic;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CollectionDto>(maybeCollection);
        }

        private void ValidateCollectionIsNotNull(UpdateCollectionCommand request, Collection? maybeCollection)
        {
            if (maybeCollection == null)
            {
                throw new AlreadyExistsException(nameof(Collection), request.Name);
            }
        }
    }
}
