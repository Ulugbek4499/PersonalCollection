using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Application.Commons.Interfaces;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.UseCases.Collections.Queries.GetCollections
{
    public record GetCollectionsQuery : IRequest<CollectionDto[]>;

    public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, CollectionDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCollectionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CollectionDto[]> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
        {
            Collection[] Collections = await _context.Collections.ToArrayAsync();

            return _mapper.Map<CollectionDto[]>(Collections);
        }
    }
}
