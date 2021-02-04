using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDSPTrigger : MonoBehaviour
{

    public AK.Wwise.Event dspTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DSPTrigger()
    {
        dspTrigger.Post(gameObject);
        Debug.Log("Triggering a measure of DSP!");
    }
}
