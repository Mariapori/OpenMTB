using System.ComponentModel.DataAnnotations;
namespace OpenMTB.Models;

public class Result
{
    [Key]
    public int Id { get; set; }
    public required Participant Participant { get; set; }
    public required Series Series { get; set; }
    public required Competition Competition { get; set; }
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime? EndTime { get; set;}

    public TimeSpan? GetTime()
    {
        if(EndTime == null)
        {
            return null;
        }
        return StartTime - EndTime;
    }

    public string ResultString()
    {
        return $"{GetTime()?.Hours}:{GetTime()?.Minutes}:{GetTime()?.Seconds}:{GetTime()?.Milliseconds}";
    }

}