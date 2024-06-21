using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static GameObject SpawnObject(Object type, GameObject prefab, Vector3 pos, Quaternion rotation)
    {
        GameObject spawnedObject = Instantiate(prefab, pos, rotation);
        Highlighter.ChangeColorInPointByObject(new Point((int)pos.x, (int)pos.z), type);
        
        return spawnedObject;
    }
}
