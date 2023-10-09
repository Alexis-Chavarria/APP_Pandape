using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infrastructure.Queries.Candidates
{
    public record GetAllCandidatesQuery:IRequest<IEnumerable<CandidateDto>>;
}
