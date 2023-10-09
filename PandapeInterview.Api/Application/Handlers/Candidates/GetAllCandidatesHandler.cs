using MediatR;
using Microsoft.EntityFrameworkCore;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Queries.Candidates;

namespace PandapeInterview.Application.Handlers.Candidates
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDto>>
    {
        private readonly ApplicationDbContext _Context;
        public GetAllCandidatesHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var Candidates = await _Context.Candidates.ToListAsync(cancellationToken);
            return Candidates.Select(candidate=>new CandidateDto
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Email = candidate.Email,
                Birthdate= candidate.Birthdate,
                InsertDate  =  candidate.InsertDate,
                ModifyDate= candidate.ModifyDate,
            });
        }
    }
}
