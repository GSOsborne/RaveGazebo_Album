using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class WallSwitchOnSpeed : MonoBehaviour
{
    public GameObject slowWalls, medWalls, fastWalls;
    // Start is called before the first frame update
    void Start()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange += ChangeWalls;
        ChangeWalls(PlaybackSpeed.Medium);
        
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= ChangeWalls;
    }

    void ChangeWalls(PlaybackSpeed speed)
    {
        switch (speed)
        {
            case PlaybackSpeed.Slow:
                medWalls.SetActive(false);
                fastWalls.SetActive(false);
                slowWalls.SetActive(true);
                break;
            case PlaybackSpeed.Medium:
                slowWalls.SetActive(false);
                fastWalls.SetActive(false);
                medWalls.SetActive(true);
                break;
            case PlaybackSpeed.Fast:
                slowWalls.SetActive(false);
                medWalls.SetActive(false);
                fastWalls.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
