using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities;

public partial class Lophp
{
    public int Mahocphan { get; set; }

    public int? Hocki { get; set; }

    public string? Khoahoc { get; set; }

    public string Nhomlophp { get; set; } = null!;

    public int? Magv { get; set; }

    public string? Tkb { get; set; }

    public string? Tuanhoc { get; set; }

    public int? Sl { get; set; }

    public int? Dk { get; set; }

    public int? NumDubi { get; set; }

    public int? Dubi { get; set; }

    public bool? Clc { get; set; }

    public string Malophocphan { get; set; } = null!;

    public virtual Giangvien? MagvNavigation { get; set; }

    public virtual Hocphan MahocphanNavigation { get; set; } = null!;

    public virtual ICollection<Sinhvien> Mssvs { get; } = new List<Sinhvien>();
}
