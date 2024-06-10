using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform CellsParent;
    
    void FixedUpdate()
    {
        CellsParent.Rotate(Vector3.up * speed);
    }
}
