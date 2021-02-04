using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class TurnOffWithDelayOnSpeed : MonoBehaviour
{
    public GameObject[] objects;
    public PlaybackSpeed onDuring;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange += TurnOnOrOff;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= TurnOnOrOff;
    }

    void TurnOnOrOff(PlaybackSpeed givenSpeed)
    {
        StopAllCoroutines();
        if (givenSpeed == onDuring)
        {
            foreach (GameObject ob in objects)
            {
                ob.SetActive(true);
            }
        }
        else
        {

            StartCoroutine(DelayTurnOff());
        }
    }

    IEnumerator DelayTurnOff()
    {
        yield return new WaitForSeconds(delayTime);
        foreach (GameObject ob in objects)
        {
            ob.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
