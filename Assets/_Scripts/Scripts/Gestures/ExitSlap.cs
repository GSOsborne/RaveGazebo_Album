using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSlap : MonoBehaviour
{
    public enum ExitMode { exitSong, exitExperience };
    public ExitMode exitMode = ExitMode.exitExperience;

    public GameObject stopSongText;
    public GameObject quitAppText;
    public Color quitAppColor;
    public Color stopSongColor;

    public float cooldownTime;
    bool cooldownActive;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        exitMode = ExitMode.exitExperience;
        GetComponent<Renderer>().material.color = quitAppColor;
        quitAppText.SetActive(true);
        stopSongText.SetActive(false);

        DavisDnB_AudioManager.StopAllMusic += SongHasEnded;
        DavisDnB_AudioManager.StartSongEvent += SongHasStarted;
        rend = GetComponent<Renderer>();
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.StopAllMusic -= SongHasEnded;
        DavisDnB_AudioManager.StartSongEvent -= SongHasStarted;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Something has tried to enter me *SLURP*");
        if (other.tag == "Controller")
        {
            if (!cooldownActive)
            {
                if (exitMode == ExitMode.exitExperience)
                {
                    ExitTheExperience();
                }
                if (exitMode == ExitMode.exitSong)
                {
                    StopTheSong();
                    StartCoroutine(CoolDown());
                }
            }
        }
    }

    public void StopTheSong()
    {
        //Stop whatever song is playing
        DavisDnB_AudioManager.Instance.StopMusic();
        Debug.Log("Should exit the song now!");
    }

    public void ExitTheExperience()
    {
        Debug.Log("Yo, I'm trying to exit this damn experience.");
        // will probably want to make this smoother and less jarring
        Application.Quit();
    }

    public void SongHasStarted(DavisDnB_AudioManager.SongName whichSong)
    {
        Debug.Log("Exit object has switched modes to ending the song!");
        quitAppText.SetActive(false);
        stopSongText.SetActive(true);
        exitMode = ExitMode.exitSong;
        rend.material.color = stopSongColor;
        //with new toon shader
        rend.material.SetColor("_EmissionColor", stopSongColor);

    }

    public void SongHasEnded()
    {
        Debug.Log("Exit object has switched modes to quitting the game!");
        quitAppText.SetActive(true);
        stopSongText.SetActive(false);
        exitMode = ExitMode.exitExperience;
        rend.material.color = quitAppColor;
        //with new toon shader
        rend.material.SetColor("_EmissionColor", quitAppColor);

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoolDown()
    {
        cooldownActive = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldownActive = false;
    }
}
