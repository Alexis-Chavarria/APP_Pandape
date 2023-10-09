using MediatR;

namespace PandapeInterview.Infrastructure.Commands.Candidates
{
    public record DeleteCandidateCommand(int IdCandidate):IRequest<bool>;
}
