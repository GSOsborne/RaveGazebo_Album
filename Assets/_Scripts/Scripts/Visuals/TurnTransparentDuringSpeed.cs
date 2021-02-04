using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class TurnTransparentDuringSpeed : MonoBehaviour
{
    public GameObject opaqueWall;
    public GameObject transparentWall;

    PlaybackSpeed transparentSpeed = PlaybackSpeed.Fast;
    // Start is called before the first frame update
    void Start()
    {
        opaqueWall.SetActive(true);
        transparentWall.SetActive(false);

        DavisDnB_AudioManager.PlaybackSpeedChange += SwitchBetweenWalls;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= SwitchBetweenWalls;
    }

    void SwitchBetweenWalls(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == transparentSpeed)
        {
            opaqueWall.SetActive(false);
            transparentWall.SetActive(true);
        }
        else
        {
            opaqueWall.SetActive(true);
            transparentWall.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
