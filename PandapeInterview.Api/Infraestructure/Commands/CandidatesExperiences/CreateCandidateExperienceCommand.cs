using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infrastructure.Commands.CandidatesExperiences
{
    public record CreateCandidateExperienceCommand(
        int idCandidate,
        string company,
        string job,
        string description,
        double salary,
        DateTime beginDate,
        DateTime? endDate,
        DateTime insertDate,
        DateTime? modifyDate) :IRequest<CandidateExperiencesDto>;
}
