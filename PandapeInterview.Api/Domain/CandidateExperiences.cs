using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandapeInterview.Domain
{
    public class CandidateExperiences
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidateExperience { get; set; }
        [ForeignKey("Candidates")]
        public int IdCandidate { get; set; }
        [Required]
        [StringLength(100)]
        public string Company { get; set; }
        [Required]
        [StringLength(100)]
        public string Job { get; set; }
        [Required]
        [StringLength(4000)]
        public string Description { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public DateTime BegindDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        #region Relations
        public Candidate Candidates { get; set; } 
        #endregion
    }
}
