using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbStoreMaster.Shared;
public class Bulb
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Description { get; set; }

    [Required]
    [StringLength(50)]
    public string? type { get; set; }

    [Required]
    public int Power { get; set; }

    [Required]
    public int Lumens { get; set; }

    [Required]
    [StringLength(15)]
    public string? Color { get; set; }

    [Required]
    [StringLength(15)]
    public string? Cod { get; set; }
}
