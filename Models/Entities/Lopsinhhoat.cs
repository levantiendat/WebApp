using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities1;

public partial class Lopsinhhoat
{
    public int Id { get; set; }

    public string? Lopsh { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();
}
