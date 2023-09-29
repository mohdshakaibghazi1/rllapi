using System;
using System.Collections.Generic;

namespace RllApi.Models;

public partial class LoginUser
{
    public string EmailId { get; set; } = null!;

    public string? Password { get; set; }

    public int? NumberOfDependents { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
