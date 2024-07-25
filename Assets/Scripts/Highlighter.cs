using System.Collections.Generic;
using UnityEngine;
public class Highlighter : MonoBehaviour
{
    static private Material _firstPlayerMaterial;
    static private Material _secondPlayerMaterial;

    public static void SetMaterials(Material firstPlayerMaterial, Material secondPlayerMaterial)
    {
        _firstPlayerMaterial = firstPlayerMaterial;
        _secondPlayerMaterial = secondPlayerMaterial;
    }

    public static void HighlightOn(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public static void HighlightOff(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    public static void ChangeColorInPointByObject(Point pos, Object obj)
    {
        Field.SetCellMaterial(pos, obj.PlayerNumber == 0? _firstPlayerMaterial : _secondPlayerMaterial);
    }

    public static void HiglightPossiblePlacesToMove(int chipIndex, bool isActive)
    {
        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        List<Point> possiblePlacesToMove = player.GetPossiblePlacesMoveTo(chipIndex);

        foreach (Point possiblePlaceMoveTo in possiblePlacesToMove)
        {
            if (isActive)
            {
                Field.SetCellMaterial(possiblePlaceMoveTo, StartGame.CanMoveMaterial);
            }
            else
            {
                Field.SetCellMaterial(possiblePlaceMoveTo, StartGame.Materials[Field.GetCellLayer(possiblePlaceMoveTo)]);
            }
        }
    }
}
