using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Repository.Interfaces;

public interface IMatchRepository
{
    public Match UpdateMatch(Match match);
    public MatchDTO CreateMatch(MatchDTO match);
}