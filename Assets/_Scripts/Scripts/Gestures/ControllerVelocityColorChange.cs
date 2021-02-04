using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVelocityColorChange : MonoBehaviour
{
    float triggerSpeed;
    float coolingDownTime;
    Animation colorAnim;
    GestureTracking gTrack;

    public Vector3 Velocity { get; private set; }
    public Vector3 HandPosition { get; private set; }

    public bool checkThisIfLeftController;

    private Vector3 prevPos;

    bool wallTriggerReceptionPause;

    


    // Start is called before the first frame update
    void Start()
    {
        gTrack = GetComponent<GestureTracking>();
        triggerSpeed = gTrack.triggerSpeed;
        coolingDownTime = gTrack.cooldownTime;
        colorAnim = GetComponent<Animation>();
        colorAnim.Play("ControllerVelocityAnim");
        colorAnim["ControllerVelocityAnim"].speed = 0;
        colorAnim["ControllerVelocityAnim"].normalizedTime = 0;

        Velocity = Vector3.zero;
        wallTriggerReceptionPause = false;

        DavisDnB_AudioManager.WallTriggerEvent += PauseAtMax;

    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= PauseAtMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wallTriggerReceptionPause)
        {
            colorAnim["ControllerVelocityAnim"].normalizedTime = Mathf.Clamp(gTrack.currentVelocity.magnitude / triggerSpeed, 0f, 1f);
        }

        /*
        if (checkThisIfLeftController)
        {
            Velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            //Debug.Log("Velocity of left controller is: " + Velocity);
        }
        else
        {
            Velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            //Debug.Log("Velocity of right controller is: " + Velocity);
        }
        if (!wallTriggerReceptionPause)
        {
            colorAnim["ControllerVelocityAnim"].normalizedTime = Mathf.Clamp(Velocity.magnitude / triggerSpeed, 0f, 1f);
            //Debug.Log(Velocity.magnitude / triggerSpeed);
        }
        */
    }

    private void PauseAtMax(MusicLayer mLayer)
    {
                StartCoroutine(PauseAtMaxRoutine());

    }

    IEnumerator PauseAtMaxRoutine()
    {
        wallTriggerReceptionPause = true;
        colorAnim["ControllerVelocityAnim"].normalizedTime = 1f;
        yield return new WaitForSeconds(coolingDownTime);
        wallTriggerReceptionPause = false;
    }
}
