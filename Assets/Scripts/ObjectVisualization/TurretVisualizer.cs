using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVisualizer : MonoBehaviour
{
    [SerializeField] private float _adjusmentRotation = 180; //для этой модельки 90

    private Vector3 _coordinateTurret;
    private void Start()
    {
        _coordinateTurret = GetComponent<Transform>().position;
        print(_coordinateTurret);
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
                var clickCoordinateV3 = click.transform.position;
                Point coordinate = new((int)_coordinateTurret.x, (int)_coordinateTurret.z);
                Point clickCoordinateP = new((int)clickCoordinateV3.x, (int)clickCoordinateV3.z);
                if (clickCoordinateP.GetDistSquared(coordinate) != 1) 
                {
                    return;
                }
                Turret turret = new();
                Point direction = clickCoordinateP - coordinate;
                turret.SetDirection(direction);
                /*print(direction.x);
                print(direction.y);*/
                PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber].BuyObject(turret, coordinate);
                Point[] directions = {new(0, 1), new(1, 0), new(0, -1), new(-1, 0) };
                for (int i = 0; i < directions.Length; i++) 
                {
                    if (directions[i].x == direction.x && directions[i].y == direction.y) 
                    {
                        print(i);
                        transform.rotation = Quaternion.Euler(0, 90 * i + _adjusmentRotation, 0);
                        break;
                    }
                }
                enabled = false;
                CurrentPlayer.NextPlayer();
            }
        }
    }
}
