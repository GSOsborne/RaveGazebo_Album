using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class GestureTowardsWallsTutorial : MonoBehaviour
{
    public GameObject gestureText, changeBoxText, haveFunText;
    public float requiredChargeLevel, haveFunTime;
    

    bool gesturePassed;
    bool boxChangedSuccessfully;
    // Start is called before the first frame update
    void Start()
    {
        gestureText.SetActive(false);
        gesturePassed = false;
        boxChangedSuccessfully = false;
        DavisDnB_AudioManager.StartSongEvent += TurnOnText;
        DavisDnB_AudioManager.PlaybackSpeedChange += BoxWasChanged;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.StartSongEvent -= TurnOnText;
        DavisDnB_AudioManager.PlaybackSpeedChange -= BoxWasChanged;
    }

    void TurnOnText(SongName songName)
    {
        gestureText.SetActive(true);
        gesturePassed = false;
        boxChangedSuccessfully = false;
    }

    void BoxWasChanged(PlaybackSpeed givenSpeed)
    {
        if (gesturePassed && !boxChangedSuccessfully)
        {
            changeBoxText.SetActive(false);
            boxChangedSuccessfully = true;
            StartCoroutine(HaveFun());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DavisDnB_AudioManager.Instance.chargeLevel > requiredChargeLevel && !gesturePassed)
        {
            gestureText.SetActive(false);
            changeBoxText.SetActive(true);
            gesturePassed = true;
        }

    }

    IEnumerator HaveFun()
    {
        haveFunText.SetActive(true);
        yield return new WaitForSeconds(haveFunTime);
        haveFunText.SetActive(false);
    }
}
