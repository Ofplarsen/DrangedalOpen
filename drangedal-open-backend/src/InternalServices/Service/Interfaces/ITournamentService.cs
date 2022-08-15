using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface ITournamentService
{
    public Tournament GenerateTournament();
}