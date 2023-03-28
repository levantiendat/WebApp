using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities1;

public partial class Khoa
{
    public int Id { get; set; }

    public string? Makhoa { get; set; }

    public virtual ICollection<Giangvien> Giangviens { get; } = new List<Giangvien>();

    public virtual ICollection<Hocphan> Hocphans { get; } = new List<Hocphan>();
}
