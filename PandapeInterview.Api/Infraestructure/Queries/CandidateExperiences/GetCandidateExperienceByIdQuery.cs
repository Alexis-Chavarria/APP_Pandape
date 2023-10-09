using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infraestructure.Queries.CandidateExperiences
{
    public record GetCandidateExperienceByIdQuery(int IdCandidateExperence): IRequest<CandidateExperiencesDto>;
}
