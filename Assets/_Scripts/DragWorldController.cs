using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static DragMovement;

public class DragWorldController : MonoBehaviour
{
    ActionBasedController xrController;

    Vector3 lastFramePos;
   
    // Start is called before the first frame update
    void Start()
    {
        xrController = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (xrController.selectInteractionState.activatedThisFrame)
        {
            lastFramePos = transform.localPosition;
            //Debug.Log("First frame position was " + lastFramePos);
        }


        if (xrController.selectInteractionState.active)
        {
            //Debug.Log("Grabbing the PHAT world with " + this.name);
            Vector3 sentVector = lastFramePos - transform.localPosition;
            DragMovement.Instance.RecieveMovementVector(sentVector);
            lastFramePos = transform.localPosition;
        }

        //Vector3 positionVector = xrController.positionAction.action.ReadValue<Vector3>();
        //Debug.Log(positionVector);
        
    }

}
