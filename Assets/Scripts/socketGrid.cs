using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGrid : MonoBehaviour
{
    public float gridPlaneHeight; //distance above y=0
    public float gridSize; //distance between grid points

    /// <summary>
    /// Defines the lower bounds of the grid
    /// </summary>
    public Vector2Int minimum;
    /// <summary>
    /// Defines the upper bounds of the grid
    /// </summary>
    public Vector2Int maximum;
    public GameObject socketObject;

    private Vector3 truePos;

    void Start()
    {
        
        //Ensure the minimum vector is smaller than the maximum vector
        if (minimum.x > maximum.x)
        {
            int tempX = minimum.x;
            minimum.x = maximum.x;
            maximum.x = tempX;
        }
        if (minimum.y > maximum.y)
        {
            int tempY = minimum.y;
            minimum.y = maximum.y;
            maximum.y = tempY;
        }

        for (int i = minimum.x; i <= maximum.x; i++)
        {
            for (int j = minimum.y; j <= maximum.y; j++)
            {
                string key = string.Format($"{0},{1}", i, j);

                Instantiate(socketObject, this.transform.position + new Vector3(i * gridSize, gridPlaneHeight, j * gridSize), Quaternion.identity, this.transform);
            }
        }
    }
}
