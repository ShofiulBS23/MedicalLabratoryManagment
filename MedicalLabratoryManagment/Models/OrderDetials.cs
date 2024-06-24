using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalLabratoryManagment.Models;

public class OrderDetials
{
    [Key]
    public int DetailID { get; set; } // Assumed to have an ID

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Minivalue { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Maxvalue { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Result { get; set; } = 0;
    [MaxLength(20)]
    public string State { get; set; } = String.Empty;


    // Navigation properties
    public int BillNo { get; set; }
    public int? BillId { get; set; }
    public virtual Bill Bill { get; set; }

    public int? TestID { get; set; }
    public virtual Test Test { get; set; }
    public int? PatientID { get; set; }
    public virtual Patient Patient { get; set; }
}
