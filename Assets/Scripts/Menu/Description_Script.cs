using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description_Script : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    void OnMouseOver()
    {
        Panel.SetActive(true);
    }

    void OnMouseExit()
    {
        Panel.SetActive(false);
    }
}
