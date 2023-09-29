using System;
using System.Collections.Generic;

namespace RllApi.Models;

public partial class VaccineCentre
{
    public int CentreId { get; set; }

    public string? HospitalName { get; set; }

    public string? Address { get; set; }

    public string? District { get; set; }

    public decimal? Sales { get; set; }

    public string? PinCode { get; set; }

    public string? VaccineName { get; set; }

    public decimal? VaccineCost { get; set; }

    public virtual ICollection<LoginAdmin> LoginAdmins { get; set; } = new List<LoginAdmin>();

    public virtual ICollection<Member> MemberDose1Centres { get; set; } = new List<Member>();

    public virtual ICollection<Member> MemberDose2Centres { get; set; } = new List<Member>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
