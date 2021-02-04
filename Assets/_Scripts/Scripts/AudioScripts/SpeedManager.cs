using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class SpeedManager : MonoBehaviour
{
    public float changeSpeedFrameLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpeed(float givenRTPCValue)
    {
        Debug.Log("Gonna shift speeds, watch out!");
        StopAllCoroutines();
        //AkSoundEngine.PostEvent("OpenFills", DavisDnB_AudioManager.Instance.gameObject);
        StartCoroutine(FadeToNewSpeed(givenRTPCValue));
        PlaybackSpeed pSpeed;
        if (givenRTPCValue == 10)
        {
            pSpeed = PlaybackSpeed.Slow;
        }
        else if(givenRTPCValue == 50)
        {
            pSpeed = PlaybackSpeed.Medium;
        }
        else if(givenRTPCValue == 90)
        {
            pSpeed = PlaybackSpeed.Fast;
        }
        else
        {
            Debug.Log("I'm confused by these playback speed rtpc values you're sending me!");
            pSpeed = PlaybackSpeed.Medium;
        }
        DavisDnB_AudioManager.Instance.PlaybackSpeedChangeEvent(pSpeed);
    }

    IEnumerator FadeToNewSpeed(float targetRTPC)
    {
        float outrtpc;
        int reftype = 1;
        AkSoundEngine.GetRTPCValue("PlaybackSpeedRTPC", null, 0, out outrtpc, ref reftype);
        //Debug.Log(outrtpc);
        float currentRTPC = outrtpc;
        Debug.Log("Beginning Speed change now.");

        for(int i = 0; i <= 10; i++)
        {
            currentRTPC = Mathf.Lerp(outrtpc, targetRTPC, i / 10);
            AkSoundEngine.SetRTPCValue("PlaybackSpeedRTPC", currentRTPC);
            yield return new WaitForSeconds(changeSpeedFrameLength);
        }
        Debug.Log("Finished shifting to RTPC Value: " + currentRTPC);
    }
}
