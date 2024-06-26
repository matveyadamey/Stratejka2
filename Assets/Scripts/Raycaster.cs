using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Vector3 clickPosition;
    void moveChip()
    {
        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
        CurrentPlayer.MovementChip.Move(lastClick);
    }
    void buyObject()
    {
        Vector3 place = new Vector3(clickPosition.x, 1, clickPosition.z);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        Point p = new Point((int)place.x, (int)place.z);

        if (!player.CanBuyObject(CurrentPlayer.TypePurchasedObject, p))
        {
            return;
        }

        Field.DeleteCoin(p);

        GameObject spawnedObject = ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, place, Quaternion.identity);

        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.TypePurchasedObject = null;
        CurrentPlayer.PurchasedObject = null;
        CurrentPlayer.NextPlayer();
    }
    void OnClick()
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
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;

                if ((CurrentPlayer.PurchasedObject != null & CurrentPlayer.TypePurchasedObject != null) || CurrentPlayer.MovementChip != null)
                {
                    if (click.transform.position != clickPosition)
                    {
                        if (click.tag == "Cell")
                        {
                            clickPosition = click.transform.position;
                            OnClick();
                        }
                    }
                }
            }
        }
    }

}
