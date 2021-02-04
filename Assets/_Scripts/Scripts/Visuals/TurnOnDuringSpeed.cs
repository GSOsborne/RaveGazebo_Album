using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class TurnOnDuringSpeed : MonoBehaviour
{
    public GameObject[] objects;
    public PlaybackSpeed onDuring;

    // Start is called before the first frame update
    void Start()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange += TurnOnOrOff;
    }

    void TurnOnOrOff(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == onDuring)
        {
            foreach (GameObject ob in objects){
                ob.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject ob in objects)
            {
                ob.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
