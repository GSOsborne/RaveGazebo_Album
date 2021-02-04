using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class TurnOffPanelTextAfterWack : MonoBehaviour
{
    public int requiredSpeedChanges = 3;
    int count;
    public GameObject[] textToTurnOff;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        DavisDnB_AudioManager.PlaybackSpeedChange += AddToCount;
        DavisDnB_AudioManager.StartSongEvent += ResetCount;
        DavisDnB_AudioManager.StopAllMusic += TurnOffText;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= AddToCount;
        DavisDnB_AudioManager.StartSongEvent -= ResetCount;
        DavisDnB_AudioManager.StopAllMusic -= TurnOffText;
    }

    void AddToCount(PlaybackSpeed pSpeed)
    {
        count++;
        if (count == requiredSpeedChanges)
        {
            foreach (GameObject text in textToTurnOff)
            {
                text.SetActive(false);
            }
        }
    }

    void ResetCount(SongName sName)
    {
        count = 0;
        foreach (GameObject text in textToTurnOff)
        {
            text.SetActive(true);
        }
    }

    void TurnOffText()
    {
        foreach (GameObject text in textToTurnOff)
        {
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
