using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentVariables : MonoBehaviour
{
    public static PersistentVariables Instance { get; private set; }

    public float maximumSocketRange;
    //More global variables can go here

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
