using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Show001
    {
        public string? MALOPHOCPHAN { get; set; }
        [Key]
        public string? TENLOP { get; set; }
        public double? TC { get; set; }
        public string? GV { get; set; }
        public string? TKB { get; set; }
        public string? week { get; set; }
        public int SL { get; set; }
        public int DK { get; set; }
        public int ndb { get; set; }
        public int db { get; set; }
        public bool clc { get; set; }
    }
}
