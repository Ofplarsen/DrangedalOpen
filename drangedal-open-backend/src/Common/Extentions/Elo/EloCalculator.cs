using Common.Models.Tournament;

namespace Common.Extentions.Elo;

public static class EloCalculator
{
    public static float Probability(int rating1,
        int rating2)
    {
        return 1.0f * 1.0f / (1 + 1.0f *
            (float)(Math.Pow(10, 1.0f *
                (rating1 - rating2) / 400)));
    }
      
    // Function to calculate Elo rating
    // K is a constant.
    // d determines whether Player A wins or
    // Player B.
    public static void EloRating(Ranking winner, Ranking loser)
    {
        int K = 30;
        // To calculate the Winning
        // Probability of Player B
        float Pb = Probability(winner.Rating, loser.Rating);
      
        // To calculate the Winning
        // Probability of Player A
        float Pa = Probability(loser.Rating, winner.Rating);
      
        // Case -1 When Player A wins
        // Updating the Elo Ratings

        winner.Rating = (int)(winner.Rating + K * (1 - Pa));
        loser.Rating = (int)(loser.Rating + K * (0 - Pb));

    }
    
}