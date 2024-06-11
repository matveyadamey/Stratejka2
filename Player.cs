using System.Collections.Generic;
public class Player
{
    public int CountCoins = 0;
    private Point[] _coordChip;
    private int _playerNumber;


    public Player(int playerNumber)
    {
        _coordChip = new Point[2] { new Point(-1,-1), new Point(-1,-1) };
        _playerNumber = playerNumber;
    }
    public void SetCoordChip(int chipNumber, Point coord)
    {
        if (_coordChip[chipNumber] == new Point(-1, -1));
        {
            _coordChip[chipNumber] = coord;
            MapObject.SetObject(new Chip(_playerNumber), coord);
        }
    }

    public bool CanMoveChip(int chipIndex, Point placeMoveTo)
    {
        return MapObject.IsCoordValid(placeMoveTo) && !MapObject.IsDealtDamage(placeMoveTo, _playerNumber) && 
               (placeMoveTo.GetDistSquared(_coordChip[chipIndex]) == 1) &&
               MapObject.GetObject(placeMoveTo) == null;
    }
    public List<Point> GetPossiblePlacesMoveTo(int chipIndex)
    {
        List<Point> possiblePlacesMoveTo= new List<Point>();
        Point chipPosition = _coordChip[chipIndex];

        int left = chipPosition.x - 1;
        int right = chipPosition.x + 1;
        int up = chipPosition.y + 1;
        int down = chipPosition.y - 1;

        for (int x = left; x <= right; x++)
        {
            for (int y = down; y <= up; y++)
            {
                Point possiblePlaceMoveTo = new Point(x, y);

                if (CanMoveChip(chipIndex, possiblePlaceMoveTo))
                {
                    possiblePlacesMoveTo.Add(possiblePlaceMoveTo);
                }
            }
        }
        return possiblePlacesMoveTo;
    }

    public bool IsChipsInCenter()
    {
        return Point.InCenter(_coordChip[0]) && Point.InCenter(_coordChip[1]);
    }
    public void MoveChip(int chipIndex, Point placeMoveTo)
    {
        MapObject.DeleteObject(_coordChip[chipIndex]);
        _coordChip[chipIndex] = placeMoveTo;
        MapObject.SetObject(new Chip(_playerNumber), _coordChip[chipIndex]);

        CountCoins += MapCoins.GetCoinValue(placeMoveTo);
        MapCoins.DeleteCoin(placeMoveTo);
    }

    public bool CanBuyObject(Object type, Point p)
    {
        return CountCoins >= type.Cost && MapObject._map[p.x, p.y] == null;
    }
    public void BuyObject(Object type, Point p)
    {
        CountCoins -= type.Cost;
        MapObject._map[p.x, p.y] = type;
    }
}