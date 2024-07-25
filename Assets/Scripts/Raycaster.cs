using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Vector3 _clickPosition;
    private static bool _enabled = false;
    public static void ChangeEnabled()
    {
        _enabled = !_enabled;
    }

    private void moveChip()
    {
        Point lastClick = new Point((int)_clickPosition.x, (int)_clickPosition.z);
        CurrentPlayer.MovementChip.Move(lastClick);
    }
    private void buyObject()
    {
        Vector3 place = new Vector3(_clickPosition.x, 1, _clickPosition.z);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        Point p = new Point((int)place.x, (int)place.z);

        if (!player.CanBuyObject(CurrentPlayer.TypePurchasedObject, p))
        {
            return;
        }

        Field.DeleteCoin(p);

        GameObject spawnedObject = ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, place, Quaternion.identity);
        if (CurrentPlayer.TypePurchasedObject.Type == "turret") 
        {
            CurrentPlayer.LastPurchasedTurret = new Turret();
            CurrentPlayer.LastPurchasedTurret.Coordinate = p;
        }
        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.TypePurchasedObject = null;
        CurrentPlayer.PurchasedObject = null;
        CurrentPlayer.NextPlayer();
    }
    private void OnClick()
    {
        switch (CurrentPlayer.OperatingMode)
        {
            case "movement_chip":
                moveChip();
                break;

            case "buy_object":
                buyObject();
                break;

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !_enabled)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;

                if ((CurrentPlayer.PurchasedObject != null & CurrentPlayer.TypePurchasedObject != null) || CurrentPlayer.MovementChip != null)
                {
                    if (click.transform.position != _clickPosition)
                    {
                        if (click.tag == "Cell")
                        {
                            _clickPosition = click.transform.position;
                            OnClick();
                        }
                    }
                }
            }
        }
        if (WinCondition.NumberWinningPlayer() != 0)
        {
            Win.ShowWinScreen();
            enabled = true;
        }
    }

}
