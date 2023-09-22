using System;
using System.Collections.Generic;

namespace vindovino_candidates.Models;

public partial class Candidate
{
    public int IdCandidate { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Email { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Candidateexperience> Candidateexperiences { get; set; } = new List<Candidateexperience>();
}
