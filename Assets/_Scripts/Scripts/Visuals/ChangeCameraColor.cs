using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ChangeCameraColor : MonoBehaviour
{
    Camera cam;
    public Color whenOrange, whenYellow, whenGreen, whenBlue, whenPurple, whenRed;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        DavisDnB_AudioManager.WallTriggerEvent += ChangeBackground;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeBackground;
    }

    void ChangeBackground(MusicLayer givenLayer)
    {
        switch (givenLayer)
        {
            case MusicLayer.Charleston:
                cam.backgroundColor = whenYellow;
                break;
            case MusicLayer.Dholak:
                cam.backgroundColor = whenRed;
                break;
            case MusicLayer.Funk:
                cam.backgroundColor = whenPurple;
                break;
            case MusicLayer.OGProd:
                cam.backgroundColor = whenBlue;
                break;
            case MusicLayer.Sniper:
                cam.backgroundColor = whenGreen;
                break;
            case MusicLayer.Squeaker:
                cam.backgroundColor = whenOrange;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
