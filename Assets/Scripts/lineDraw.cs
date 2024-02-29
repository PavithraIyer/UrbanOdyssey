using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public float maximumDistance;
    public GameObject gridPointer;
    public Transform heldItemPoint;
    [HideInInspector]
    public Transform snapPoint;

    private LineRenderer line;
    private float closestDistance;
    private float maxRange;
    

    void Start()
    {
        line = GetComponent<LineRenderer>();
        maxRange = PersistentVariables.Instance.maximumSocketRange;
        print("maxRange:" + maxRange);
    }

    // Update is called once per frame
    void Update()
    {
        //If no object is currently in hand, do not draw this
        //Technically, this currently only stops updating its location, but we'll get to that later
        if (heldItemPoint != null)
        {
            float closestDistance = Mathf.Infinity;
            snapPoint = null;
            foreach (Transform child in gridPointer.transform)
            {
                //Disable all sphere colliders each frame
                child.Find("socketPoint").gameObject.GetComponent<SphereCollider>().enabled = false;

                float distance = (heldItemPoint.transform.position - child.transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    snapPoint = child;
                }
            }
            if (closestDistance <= maximumDistance)
            {
                //Only draw when within a given range
                line.enabled = true;
                //Enable only the closest collider
                snapPoint.Find("socketPoint").gameObject.GetComponent<SphereCollider>().enabled = true;
                line.SetPosition(0, heldItemPoint.position);
                line.SetPosition(1, snapPoint.position);
                //TODO: Set up a proper material for this
            }
            else
            {
                line.enabled = false;
            }
        }
        
    }
}
