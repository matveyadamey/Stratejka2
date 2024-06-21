using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVisualizer : MonoBehaviour
{

    private int _currentPlayerNumber = CurrentPlayer.CurrentPlayerNumber;

    private void Start()
    {
        Raycaster.ChangeEnabled();
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
                Point coordClick = new Point((int)click.transform.position.x, (int)click.transform.position.z);
                Point coordinate = CurrentPlayer.LastPurchasedTurret.Coordinate;
                if (coordClick.GetDistSquared(coordinate) != 1)
                    return;

                CurrentPlayer.LastPurchasedTurret.SetDirection(coordClick);



                if (CurrentPlayer.CurrentPlayerNumber != _currentPlayerNumber)
                {
                    CurrentPlayer.NextPlayer();
                }
                Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
                player.BuyObject(CurrentPlayer.LastPurchasedTurret, coordinate);
                CurrentPlayer.LastPurchasedTurret = null;
                float y_angle = 0;
                Point dist = coordClick - coordinate;
                if (dist == new Point(0, 1))
                {
                    y_angle = 90f;
                }
                else if (dist == new Point(1, 0))
                {
                    y_angle = 180f;
                }
                else if (dist == new Point(0, -1))
                {
                    y_angle = 270f;
                }
                transform.rotation = Quaternion.Euler(-90, y_angle, 0);

                CurrentPlayer.NextPlayer();

                Raycaster.ChangeEnabled();
                enabled = false;

            }
        }
    }
}
