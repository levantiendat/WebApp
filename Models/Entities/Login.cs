using System;
using System.Collections.Generic;

namespace WebApp1.Models.Entities;

public partial class Login
{
    public string Mssv { get; set; } = null!;

    public string? Password { get; set; }
}
