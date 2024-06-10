using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGeneration : MonoBehaviour
{
    [SerializeField] private double fieldSize;
    [SerializeField] private double fullness; 
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Vector3 adjusmentVector;

    private System.Random rand = new System.Random();

    private Vector3 generateRandomPosition(int x,int y)
    {
        double x_rand = rand.NextDouble() + x * fullness;
        double y_rand = rand.NextDouble() + y * fullness;
        Vector3 position = new Vector3(((float)x_rand), 1, (float)y_rand) + adjusmentVector;
        return position;
    }
    private void Generate()
    {
        for(int x = 0; x <fieldSize/fullness; x++)
        {
            for(int y=0; y <fieldSize/fullness; y++)
            {
                int objectNum = rand.Next(0, objects.Length);
                Vector3 position = generateRandomPosition(x, y);
                Instantiate(objects[objectNum], position, Quaternion.identity);
            }
        }
    }
    private void Start()
    {
        if (fieldSize < fullness || fullness == 0)
        {
            Debug.Log("invalid fullness");
            return;
        }

        Generate();   
    }


}
