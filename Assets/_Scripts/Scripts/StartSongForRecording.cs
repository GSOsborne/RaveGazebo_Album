using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class StartSongForRecording : MonoBehaviour
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
        DavisDnB_AudioManager.Instance.TriggerWallEvent(whichLayer);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
