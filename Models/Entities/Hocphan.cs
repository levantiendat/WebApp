using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities1;

public partial class Hocphan
{
    public int Id { get; set; }

    public string? Namehp { get; set; }

    public double? Tinchi { get; set; }

    public int? Makhoa { get; set; }

    public virtual ICollection<Lophp> Lophps { get; } = new List<Lophp>();

    public virtual Khoa? MakhoaNavigation { get; set; }
}
