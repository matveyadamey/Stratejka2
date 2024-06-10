public static class PlayersContainer
{
    public static Player[] Players { get; } = new Player[StartGame.ChipsCount];
    
    public static void MakePlayers()
    {
        for(int i = 0; i < StartGame.ChipsCount; i++)
        {
            Players[i] = new Player(i);
        }
    }
}
