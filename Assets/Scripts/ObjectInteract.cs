using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteract : MonoBehaviour
{
    XRDirectInteractor interactor = null;
    GameObject grabbedObject = null;
    public void ObjectGrabbed()
    {
        interactor = GetComponent<XRDirectInteractor>();
        grabbedObject = interactor.selectTarget.gameObject;

        //Set attach transform reference to the child object (which should only be the model on the grab object)
        grabbedObject.GetComponent<XRGrabInteractable>().attachTransform = grabbedObject.transform.GetChild(0);
    }

    public void ObjectReleased()
    {
        //return object reference to null
        grabbedObject.GetComponent<XRGrabInteractable>().attachTransform = null;
    }
}
