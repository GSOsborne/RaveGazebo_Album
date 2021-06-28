using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class StartSong2ForRecording : MonoBehaviour
{
    public SongName whichSong;
    public MusicLayer whichLayer;
    public PlaybackSpeed whichSpeed;
    public SpeedManager speedManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AfterBriefPause());
    }

    IEnumerator AfterBriefPause()
    {
        yield return null;
        DavisDnB_AudioManager.Instance.PlaybackSpeedChangeEvent(whichSpeed);
        switch (whichSpeed)
        {
            case PlaybackSpeed.Slow:
                speedManager.ChangeSpeed(10f);
                break;
            case PlaybackSpeed.Medium:
                speedManager.ChangeSpeed(50f);
                break;
            case PlaybackSpeed.Fast:
                speedManager.ChangeSpeed(90f);
                break;
        }
        yield return new WaitForSeconds(1f);
        DavisDnB_AudioManager.Instance.StartASong(whichSong);
        for (int i = 1; i <= 3; i++)
        {
            float randomWall = Mathf.FloorToInt(Random.Range(0, 6));
            Debug.Log("Random wall int was: " + randomWall);
            if (randomWall == 0)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.Charleston);
            }
            else if (randomWall == 1)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.Dholak);
            }
            else if (randomWall == 2)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.Funk);
            }
            else if (randomWall == 3)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.OGProd);
            }
            else if (randomWall == 4)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.Sniper);
            }
            else if (randomWall == 5)
            {
                DavisDnB_AudioManager.Instance.TriggerWallEvent(MusicLayer.Squeaker);
            }
            Debug.Log("Finished calling fake wall " + i);
            yield return null;
        }
        //finally trigger the correct one
        DavisDnB_AudioManager.Instance.TriggerWallEvent(whichLayer);

        Debug.Log("Song should be started now.");


    }

    // Update is called once per frame
    void Update()
    {

    }
}
