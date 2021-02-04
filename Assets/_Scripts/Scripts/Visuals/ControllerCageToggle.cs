using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ControllerCageToggle : MonoBehaviour
{
    public GameObject cage;
    public PlaybackSpeed cageSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cage.SetActive(false);
        DavisDnB_AudioManager.PlaybackSpeedChange += EvaluateCageToggle;   
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= EvaluateCageToggle;
    }

    void EvaluateCageToggle(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == cageSpeed)
        {
            cage.SetActive(true);
        }
        else
        {
            cage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
