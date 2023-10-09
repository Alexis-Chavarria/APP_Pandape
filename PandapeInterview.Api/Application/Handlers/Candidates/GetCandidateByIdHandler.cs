using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Queries.Candidates;

namespace PandapeInterview.Application.Handlers.Candidates
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        private readonly ApplicationDbContext _Context;
        public GetCandidateByIdHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<CandidateDto?> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var Candidate = await _Context.Candidates.FindAsync(new object[] { request.IdCandidate },cancellationToken);
            if (Candidate == null)
            {
                return null; 
            }
            return new CandidateDto
            {
                IdCandidate = Candidate.IdCandidate,
                Name = Candidate.Name,
                Surname= Candidate.Surname,
                Email= Candidate.Email,
                InsertDate= Candidate.InsertDate,
                ModifyDate= Candidate.ModifyDate,
                Birthdate= Candidate.Birthdate,
            };
        }
    }
}
