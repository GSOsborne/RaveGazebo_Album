using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GestureTracking : MonoBehaviour
{

    public ActionBasedController xrController;
    public float triggerSpeed;
    public float cooldownTime;
    bool resetting;

    public Vector3 currentVelocity;

    private Vector3 lastFramePos;


    RaycastHit hit;

    private void Start()
    {
        //xrController = GetComponent<ActionBasedController>();
        lastFramePos = xrController.gameObject.transform.position;
    }


    private void Update()
    {
        Vector3 currentPosition = xrController.gameObject.transform.position;
        currentVelocity = (currentPosition - lastFramePos) * Time.deltaTime;
        float controllerSpeed = currentVelocity.magnitude*1000f;
        //Debug.Log(controllerSpeed);

        if (controllerSpeed > triggerSpeed && !resetting)
        {
            RevealWalls(currentPosition, currentVelocity);

        }
        lastFramePos = currentPosition;
    }

    void RevealWalls(Vector3 controllerPosition, Vector3 controllerVelocity)
    {
        Ray checkForWall = new Ray(controllerPosition, controllerVelocity);
        if (Physics.Raycast(checkForWall, out hit, 20f))
        {
            Debug.DrawRay(controllerPosition, controllerVelocity, Color.green, 2f);
            if (hit.transform.gameObject.CompareTag("GestureWall"))
            {
                hit.transform.gameObject.GetComponent<WallTrigger>().WallTriggered();

                StartCoroutine(ResetController());
            }
            else
            {
                Debug.Log("Instead of a wall, I hit: " + hit.transform.gameObject);
            }
        }
        else
        {
            Debug.Log("the raycast didn't hit anything.");

        }
        Debug.DrawRay(controllerPosition, controllerVelocity, Color.green, 2f);
    }

    IEnumerator ResetController()
    {
        resetting = true;
        yield return new WaitForSeconds(cooldownTime);
        resetting = false;
    }


    /*
    public bool thisisLH;

    public float triggerSpeed;
    public float cooldownTime;

    RaycastHit hit;

    bool lhResetting;
    bool rhResetting;

    // Start is called before the first frame update
    void Start()
    {
        lhResetting = false;
        rhResetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisisLH)
        {
            Vector3 controllerVelocityVector = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            if(controllerVelocityVector.magnitude > triggerSpeed)
            {
                SpeedCheckPassed(OVRInput.Controller.LTouch, controllerVelocityVector);
            }
        }
        else
        {
            Vector3 controllerVelocityVector = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude > triggerSpeed)
            {
                SpeedCheckPassed(OVRInput.Controller.RTouch, controllerVelocityVector);
            }
        }
    }

    void SpeedCheckPassed(OVRInput.Controller controller, Vector3 velocityVector)
    {
        if (controller == OVRInput.Controller.LTouch && !lhResetting)
        {
            RevealWalls(controller, velocityVector);
        }
        else if (controller == OVRInput.Controller.RTouch && !rhResetting)
        {
            RevealWalls(controller, velocityVector);
        }
    }

    void RevealWalls(OVRInput.Controller controller, Vector3 velocityVector)
    {
        Ray checkForWall = new Ray(OVRInput.GetLocalControllerPosition(controller), velocityVector);
        if (Physics.Raycast(checkForWall, out hit, 50f))
        {
            Debug.DrawRay(OVRInput.GetLocalControllerPosition(controller), velocityVector, Color.green, 2f);
            if (hit.transform.gameObject.CompareTag("GestureWall"))
            {
                hit.transform.gameObject.GetComponent<WallTrigger>().WallTriggered();
                if (controller == OVRInput.Controller.LTouch)
                {
                    StartCoroutine(LHResetting());
                }
                else
                {
                    StartCoroutine(RHResetting());
                }
            }
            else
            {
                Debug.Log("Instead of a wall, I hit: " + hit.transform.gameObject);
            }
        }
        else
        {
           // Debug.Log("the raycast didn't hit anything.");

        }
        //Debug.DrawRay(OVRInput.GetLocalControllerPosition(controller), velocityVector, Color.green, 2f);

    }


    IEnumerator LHResetting()
    {
        lhResetting = true;
        yield return new WaitForSeconds(cooldownTime);
        lhResetting = false;
    }

    IEnumerator RHResetting()
    {
        rhResetting = true;
        yield return new WaitForSeconds(cooldownTime);
        rhResetting = false;
    }

    */
}
