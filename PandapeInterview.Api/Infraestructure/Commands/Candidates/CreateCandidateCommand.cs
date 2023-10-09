using MediatR;
using PandapeInterview.Application.DTOs;

namespace PandapeInterview.Infrastructure.Commands.Candidates
{
    public record CreateCandidateCommand(string Name, string Surname, DateTime Birthdate, string Email) 
        :IRequest<CandidateDto>;
   
}
