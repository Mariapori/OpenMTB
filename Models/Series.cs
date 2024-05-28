using System.ComponentModel.DataAnnotations;

namespace OpenMTB.Models;

public class Series
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual List<Result> Results { get; set; } = new List<Result>();
}