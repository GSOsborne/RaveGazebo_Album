using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavisDnB_AudioManager : MonoBehaviour
{
    public AK.Wwise.Event DavisDnBSongStart;

    public enum MusicLayer { Charleston, Dholak, Funk, OGProd, Sniper, Squeaker };

    public enum SongName { DavisDnB};

    public enum PlaybackSpeed { Slow, Medium, Fast}

    public static DavisDnB_AudioManager Instance { get; private set; }

    public static event System.Action<MusicLayer> WallTriggerEvent;
    public static event System.Action<SongName> StartSongEvent;
    public static event System.Action StopAllMusic;
    public static event System.Action<PlaybackSpeed> PlaybackSpeedChange;

    public float chargeLevel;
    public float chargeFadeMultiplier;
    public float chargeBoostValue;
    public PlaybackSpeed currentPlaybackSpeed;

    public bool songPlaying;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        songPlaying = false;
        currentPlaybackSpeed = PlaybackSpeed.Medium;
    }

    // Update is called once per frame
    void Update()
    {
        if (songPlaying)
        {
            AkSoundEngine.SetRTPCValue("ChargeLevel", chargeLevel);
        }
        if (chargeLevel > 0)
        {
            FadeCharge();
        }

    }

    public void TriggerWallEvent(MusicLayer musicLayer)
    {
        WallTriggerEvent?.Invoke(musicLayer);
        switch (musicLayer)
        {
            case MusicLayer.Charleston:
                AkSoundEngine.PostEvent("LayerCharleston", gameObject);
                break;
            case MusicLayer.Dholak:
                AkSoundEngine.PostEvent("LayerDholak", gameObject);
                break;
            case MusicLayer.Funk:
                AkSoundEngine.PostEvent("LayerFunk", gameObject);
                break;
            case MusicLayer.OGProd:
                AkSoundEngine.PostEvent("LayerOGProd", gameObject);
                break;
            case MusicLayer.Sniper:
                AkSoundEngine.PostEvent("LayerSniper", gameObject);
                break;
            case MusicLayer.Squeaker:
                AkSoundEngine.PostEvent("LayerSqueaker", gameObject);
                break;
        }
        BoostCharge();
    }



    public void StartASong(SongName whichSongName)
    {
        StartSongEvent?.Invoke(whichSongName);
        PlaybackSpeedChangeEvent(currentPlaybackSpeed);
        DavisDnBSongStart.Post(gameObject, (uint)AkCallbackType.AK_MusicSyncBar, EveryMeasure);
        Debug.Log("Started Wizard Song!");
        songPlaying = true;
        chargeLevel = 0f;
    }

    void EveryMeasure(object in_cookie, AkCallbackType in_type, object in_info)
    {
        //Debug.Log("New Measure, Closing Fills.");
        AkSoundEngine.PostEvent("CloseFills", gameObject);
    }

    public void StopMusic()
    {
        AkSoundEngine.PostEvent("StopMusic", gameObject);
        StopAllMusic?.Invoke();
        songPlaying = false;
    }

    void BoostCharge()
    {
        chargeLevel = Mathf.Clamp(chargeLevel + chargeBoostValue, 0, 100);
        //Debug.Log("Charge Level is now at: " + chargeLevel);
    }

    void FadeCharge()
    {
        if (chargeLevel > 70)
        {
            chargeLevel = Mathf.Clamp(chargeLevel - chargeFadeMultiplier / 2f * Time.deltaTime, 0, 100);
        }
        else if (chargeLevel > 40)
        {
            chargeLevel = Mathf.Clamp(chargeLevel - chargeFadeMultiplier / 1.3f * Time.deltaTime, 0, 100);
        }
        else
        {
            chargeLevel = Mathf.Clamp(chargeLevel - chargeFadeMultiplier * Time.deltaTime, 0, 100);
        }

    }


    public void PlaybackSpeedChangeEvent(PlaybackSpeed givenSpeed)
    {
        PlaybackSpeedChange?.Invoke(givenSpeed);
        Debug.Log("Changing speed to " + givenSpeed);
        currentPlaybackSpeed = givenSpeed;
    }












    //This is all just for Debugging in the canvas

    public void StartSong()
    {
        StartASong(SongName.DavisDnB);

    }

    public void TriggerCharleston()
    {
        TriggerWallEvent(MusicLayer.Charleston);
    }

    public void TriggerDholak()
    {
        TriggerWallEvent(MusicLayer.Dholak);
    }

    public void TriggerFunk()
    {
        TriggerWallEvent(MusicLayer.Funk);
    }

    public void TriggerOGProd()
    {
        TriggerWallEvent(MusicLayer.OGProd);
    }

    public void TriggerSqueaker()
    {
        TriggerWallEvent(MusicLayer.Squeaker);
    }

    public void TriggerSniper()
    {
        TriggerWallEvent(MusicLayer.Sniper);
    }
}
