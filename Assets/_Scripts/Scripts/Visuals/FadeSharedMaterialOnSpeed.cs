//using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class FadeSharedMaterialOnSpeed : MonoBehaviour
{

    Renderer rend;
    public PlaybackSpeed fadeInPlaybackSpeed;
    public float fadeInSpeed, fadeOutSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DavisDnB_AudioManager.PlaybackSpeedChange += DecideFade;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= DecideFade;
    }

    void DecideFade(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == fadeInPlaybackSpeed)
        {
            StopAllCoroutines();
            StartCoroutine(FadeMaterialIn());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FadeMaterialOut());
        }

    }

    IEnumerator FadeMaterialIn()
    {
        Color settingColor = rend.sharedMaterial.color;
        while (settingColor.a < 1)
        {
            settingColor.a += Time.deltaTime * fadeInSpeed;
            //Debug.Log("setting color a is " + settingColor.a + " on " + rend.sharedMaterial);
            rend.sharedMaterial.color = settingColor;
            yield return null;
        }


;    }

    IEnumerator FadeMaterialOut()
    {
        Color settingColor = rend.sharedMaterial.color;
        while (settingColor.a > 0)
        {
            settingColor.a -= Time.deltaTime * fadeOutSpeed;
            //Debug.Log("setting color a is " + settingColor.a + " on " + rend.sharedMaterial);
            rend.sharedMaterial.color = settingColor;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
