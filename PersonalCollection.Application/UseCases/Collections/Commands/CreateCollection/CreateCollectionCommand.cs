using AutoMapper;
using MediatR;
using PersonalCollection.Application.Commons.Exceptions;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Domain.States;

namespace PersonalCollection.Application.UseCases.Collections.Commands.CreateCollection
{
    public class CreateCollectionCommand : IRequest<CollectionDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TopicType? Topic { get; set; }
    }

    public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, CollectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public CreateCollectionCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CollectionDto> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {

            Collection maybeCollection =
                _context.Collections.SingleOrDefault(c => c.Name.Equals(request.Name));

            ValidateCollectionIsNull(request, maybeCollection);

            var collection = new Collection()
            {
                Name=request.Name,
                Description=request.Description,
                Image=request.Image,
                Topic=request.Topic
            };

            maybeCollection=_context.Collections.Add(collection).Entity;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CollectionDto>(maybeCollection); 
        }

        private void ValidateCollectionIsNull(CreateCollectionCommand request, Collection? maybeCollection)
        {
            if (maybeCollection != null)
            {
                throw new AlreadyExistsException(nameof(Collection), request.Name);
            }
        }
    }
}
    