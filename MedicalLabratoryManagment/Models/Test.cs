using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalLabratoryManagment.Models;
public class Test
{
    [Key]
    public int TestID { get; set; }

    [Required]
    public string TestName { get; set; }

    public string TestType { get; set; }

    public string SampleType { get; set; }

    public string SampleUnit { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal? MinimumValue { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal? MaximumValue { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }
}

