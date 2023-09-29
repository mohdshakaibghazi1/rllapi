using System;
using System.Collections.Generic;

namespace RllApi.Models;

public partial class Member
{
    public string AadharNumber { get; set; } = null!;

    public int? RefId { get; set; }

    public string? EmailId { get; set; }

    public string? Name { get; set; }

    public DateTime? Dob { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Dose1Status { get; set; }

    public string? Dose2Status { get; set; }

    public int? Dose1CentreId { get; set; }

    public int? Dose2CentreId { get; set; }

    public DateTime? Dose1Data { get; set; }

    public DateTime? Dose2Data { get; set; }

    public int? Dose1SlotCentreId { get; set; }

    public DateTime? Dose1SlotDate { get; set; }

    public int? Dose2SlotCentreId { get; set; }

    public DateTime? Dose2SlotDate { get; set; }

    public string? Dose1VaccineName { get; set; }

    public string? Dose2VaccineName { get; set; }

    public virtual VaccineCentre? Dose1Centre { get; set; }

    public virtual Slot? Dose1Slot { get; set; }

    public virtual VaccineCentre? Dose2Centre { get; set; }

    public virtual Slot? Dose2Slot { get; set; }

    public virtual LoginUser? Email { get; set; }
}
