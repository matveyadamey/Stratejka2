using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVisualizer : MonoBehaviour
{
    [SerializeField] private float adjusmentRotation; //для этой модельки 85
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
                Point coodinate = CurrentPlayer.LastPurchasedTurret.Coodinate;
                if (coordClick.GetDistSquared(coodinate) != 1)
                    return;
                
                CurrentPlayer.LastPurchasedTurret.SetDirection(coordClick);
                Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
                player.BuyObject(CurrentPlayer.LastPurchasedTurret, coodinate);
                CurrentPlayer.LastPurchasedTurret = null;
                float y_angle = Vector3.Angle(Vector3.forward, click.transform.position-transform.position)+adjusmentRotation;
                transform.rotation = Quaternion.Euler(-90, y_angle, 0);
                enabled = false;

            }
        }
    }
}
