using System;
using System.Collections.Generic;

namespace HidingFieldsAPI.Models;

public partial class Students
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();

    public virtual ICollection<tblLog> tblLog { get; set; } = new List<tblLog>();
}
