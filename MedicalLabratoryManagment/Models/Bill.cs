using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalLabratoryManagment.Models;

[Table("Bills")]
public class Bill
{
    [Key]
    public int BillNo { get; set; }

    [Required]
    [StringLength(50)]
    public string BillDate { get; set; }

    [Required]
    public int PatientID { get; set; }
    public Patient Patient { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal TotalPrice { get; set; }
}

