using UnityEngine;

public class CoinsCollectingVisualisation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            Destroy(other.gameObject);
        }
    }
}
