namespace PandapeInterview.Application.DTOs
{
    public class CandidateProfileVm
    {
        public CandidateDto candidate { get; set; } 
        public List<CandidateExperiencesDto> experience { get; set; }
    }
}
