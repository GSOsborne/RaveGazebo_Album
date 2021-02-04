using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTriggerPanel : MonoBehaviour
{
    PanelLifter pLift;
    public SpeedManager speedManager;
    public float sentRTPCValue;
    // Start is called before the first frame update
    void Start()
    {
        pLift = GetComponentInParent<PanelLifter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            speedManager.ChangeSpeed(sentRTPCValue);
            Debug.Log("Sent speed RTPC value of " + sentRTPCValue);
            pLift.LowerPanels();
        }
    }
}
