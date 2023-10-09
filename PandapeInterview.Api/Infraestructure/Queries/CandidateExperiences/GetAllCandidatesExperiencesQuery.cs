using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infraestructure.Queries.CandidateExperiences
{
    public record GetAllCandidatesExperiencesQuery(): IRequest<IEnumerable<CandidateExperiencesDto>>;
}
