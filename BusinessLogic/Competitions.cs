using Microsoft.EntityFrameworkCore;
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
        competition.Series = series;
        competition.Participants = participants;
        await _context.SaveChangesAsync();
        return competition;
    }
    
    public async Task<bool> RemoveCompetition(Competition competition)
    {
        try
        {
            _context.Series.RemoveRange(competition.Series);
            _context.Participants.RemoveRange(competition.Participants);
            _context.CompetitionSet.Remove(competition);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public async Task<bool> RemoveCompetition(int competitionId)
    {
        try
        {
            var competition = await _context.CompetitionSet.Include(o => o.Participants).Include(o => o.Series).ThenInclude(o => o.Results).FirstAsync(o => o.Id == competitionId);
            _context.Series.RemoveRange(competition.Series);
            _context.Participants.RemoveRange(competition.Participants);
            _context.CompetitionSet.Remove(competition);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<Competition>> GetCompetitions()
    {
        return await _context.CompetitionSet.Include(o => o.Participants).Include(o => o.Series).ThenInclude(o => o.Results).ToListAsync();
    }
}