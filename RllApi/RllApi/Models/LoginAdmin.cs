using System;
using System.Collections.Generic;

namespace RllApi.Models;

public partial class LoginAdmin
{
    public int UserId { get; set; }

    public string? Password { get; set; }

    public string? Position { get; set; }

    public int? CentreId { get; set; }

    public virtual VaccineCentre? Centre { get; set; }
}
