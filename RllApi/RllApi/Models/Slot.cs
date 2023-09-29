using System;
using System.Collections.Generic;

namespace RllApi.Models;

public partial class Slot
{
    public int CentreId { get; set; }

    public DateTime Date { get; set; }

    public virtual VaccineCentre Centre { get; set; } = null!;

    public virtual ICollection<Member> MemberDose1Slots { get; set; } = new List<Member>();

    public virtual ICollection<Member> MemberDose2Slots { get; set; } = new List<Member>();
}
