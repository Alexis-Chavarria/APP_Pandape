using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infraestructure.Queries
{
    public record GetCandidateProfileQuery(int IdCandidate): IRequest<CandidateProfileVm>;
}
