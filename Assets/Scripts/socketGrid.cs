using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGrid : MonoBehaviour
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
    public GameObject connectableObject;

    private Vector3 truePos;
    private Dictionary<string, GameObject> socketsDict;

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
        int xRange = maximum.x - minimum.x;
        int yRange = maximum.y - minimum.y;

        for (int i = minimum.x; i <= maximum.x; i++)
        {
            for (int j = minimum.y; j <= maximum.y; j++)
            {
                Debug.Log($"{i},{j}");
                string key = string.Format($"{0},{1}", i, j);
                Instantiate(socketObject, this.transform.position + new Vector3(i * gridSize, gridPlaneHeight, j * gridSize), Quaternion.identity, this.transform);
                this.transform.GetChild((i - minimum.x) * xRange + (j - minimum.y)).Find("socketPoint").GetComponent<SphereCollider>().radius = PersistentVariables.Instance.maximumSocketRange;
            }
        }
    }
}
