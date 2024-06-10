using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVisualizer : MonoBehaviour
{
    [SerializeField] private float adjusmentRotation; //для этой модельки 90
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;
                float y_angle = Vector3.Angle(Vector3.forward, click.transform.position-transform.position)+adjusmentRotation;
                transform.rotation = Quaternion.Euler(0, y_angle, 0);
                enabled = false;
            }
        }
    }
}
