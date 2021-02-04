using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeSliderRTPCUpdate : MonoBehaviour
{
    public string rtpcName;
    public Slider rtpcSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRTPC()
    {
        AkSoundEngine.SetRTPCValue(rtpcName, rtpcSlider.value);
    }
}
