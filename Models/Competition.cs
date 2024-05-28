using System.ComponentModel.DataAnnotations;

namespace OpenMTB.Models;

public class Competition
{
    [Key]
    public int Id { get; set;}
    public required string CompetitionName { get;set;}
    public virtual List<Participant> Participants {get;set; } = new List<Participant>();
    public virtual List<Series> Series {get;set; } = new List<Series>();
}