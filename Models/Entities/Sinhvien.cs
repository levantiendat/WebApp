using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities;

public partial class Sinhvien
{
    public string Mssv { get; set; } = null!;

    public string? NameSv { get; set; }

    public int? Malop { get; set; }

    public virtual Lopsinhhoat? MalopNavigation { get; set; }

    public virtual ICollection<Lophp> Malophocphans { get; } = new List<Lophp>();
}
