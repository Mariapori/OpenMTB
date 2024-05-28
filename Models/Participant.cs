using System.ComponentModel.DataAnnotations;
namespace OpenMTB.Models;

public class Participant
{
    [Key]
    public int Id { get; set;}
    
    public required string ParticipantName { get; set;}
    public required Competition ParticipantCompetition { get; set;}

}