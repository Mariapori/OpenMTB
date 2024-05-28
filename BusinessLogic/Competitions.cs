using OpenMTB.Models;

namespace OpenMTB.Data.BusinessLogic;

public class Competitions
{
    private readonly ApplicationDbContext _context;
    public Competitions(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Competition> CreateCompetition(Competition competition, List<Series> series, List<Participant> participants)
    {
        await _context.CompetitionSet.AddAsync(competition);
        await _context.SaveChangesAsync();
        return competition;
    }
    
    public async Task<bool> RemoveCompetition(Competition competition)
    {
        try
        {
            _context.CompetitionSet.Remove(competition);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}