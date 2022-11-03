using System.ComponentModel.DataAnnotations;    // Pääavain määrittely
namespace Varastonhallinta
{
    public class Varasto
    {
        [Key]
        public string? Tuotenimi { get; set; }
        public int? Tuotehinta { get; set; }
        public int? Saldo { get; set; }
    }
}
