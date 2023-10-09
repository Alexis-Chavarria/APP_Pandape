using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infrastructure.Queries.Candidates
{
    public record GetCandidateByIdQuery(int IdCandidate): IRequest<CandidateDto>;

}
