using MediatR;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.CandidatesExperiences;

namespace PandapeInterview.Application.Handlers.CandidatesExperiences
{
    public class DeleteCandidateExperienceHandler : IRequestHandler<DeleteCandidateExperienceCommand, bool>
    {
        private readonly ApplicationDbContext _Context;
        public DeleteCandidateExperienceHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<bool> Handle(DeleteCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var Experience = await _Context.CandidateExperiences.FindAsync(new object[] { request.IdCandidateExperience }, cancellationToken);
            if (Experience != null)
            {
                _Context.CandidateExperiences.Remove(Experience);
                await _Context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
