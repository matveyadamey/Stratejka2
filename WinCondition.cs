using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WinCondition
{
    public static int NumberWinningPlayer()
    {
        for (int i = 0; i < PlayersContainer.Players.Length; i++)
        {
            if (PlayersContainer.Players[i].ChipsInCenter())
            {
                return i + 1;
            }
        }
        return 0;
    }
}
