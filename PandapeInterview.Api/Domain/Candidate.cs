﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandapeInterview.Domain
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime InsertDate  { get; set; } = DateTime.Now;
        public DateTime? ModifyDate  { get; set; }

        #region Relations
        public List<CandidateExperiences> Experiences { get; set; }
        #endregion
    }
}
