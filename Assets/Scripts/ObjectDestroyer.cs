using System.Collections;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
        Point objPosition = new Point((int)transform.position.x, (int)transform.position.z);
        MapObject.DeleteObject(objPosition);
    }
}
