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

namespace PersonalCollection.Application.UseCases.Tags.Queries.GetTags
{
    public record GetTagsQuery : IRequest<TagDto[]>;

    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, TagDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTagsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TagDto[]> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            Tag[] Tags = await _context.Tags.ToArrayAsync();

            return _mapper.Map<TagDto[]>(Tags);
        }
    }
}
