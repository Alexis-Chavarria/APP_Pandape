using MediatR;

namespace PandapeInterview.Infrastructure.Commands.CandidatesExperiences
{
    public record DeleteCandidateExperienceCommand(int IdCandidateExperience):IRequest<bool>;
}
