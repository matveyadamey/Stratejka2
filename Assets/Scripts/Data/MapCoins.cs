using System;
public static class MapCoins
{
    private static int _size = StartGame.Size;
    private static Coin[,] _coinsNet;

    private static int GetLayerCount(Point p)
    {
        return Math.Min(Math.Min(p.x, p.y), Math.Min(_size - p.x - 1, _size - p.y - 1)) + 1;
    }

    public static int GetCoinValue(Point p)
    {
        return _coinsNet[p.x,p.y].coinCount;
    }

    public static void MakeMapCoins()
    {
        _coinsNet =new Coin[_size, _size];
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if((i == j && (j == 0 || j == _size - 1)) || (Math.Min(i, j) == 0 && Math.Max(i, j) == _size))
                {
                    _coinsNet[i, j] = new Coin(0);
                }
                else
                {
                    _coinsNet[i,j] = new Coin(GetLayerCount(new Point(i, j)));
                }
                
            }
        }
    }

    public static void DeleteCoin(Point Cord)
    {
        _coinsNet[Cord.x, Cord.y] = new Coin(0);
    }
}