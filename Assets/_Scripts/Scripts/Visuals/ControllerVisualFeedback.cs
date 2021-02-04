using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ControllerVisualFeedback : MonoBehaviour
{
    Renderer rend;
    PlaybackSpeed currentSpeed;
    MusicLayer currentLayer;
    public Material slowRed, slowOrange, slowYellow, slowGreen, slowBlue, slowPurple;
    public Material medRed, medOrange, medYellow, medGreen, medBlue, medPurple;
    public Material fastRed, fastOrange, fastYellow, fastGreen, fastBlue, fastPurple;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DavisDnB_AudioManager.WallTriggerEvent += ChangeColor;
        DavisDnB_AudioManager.PlaybackSpeedChange += ChangeSpeed;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeColor;
        DavisDnB_AudioManager.PlaybackSpeedChange -= ChangeSpeed;
    }

    void ChangeSpeed(PlaybackSpeed givenSpeed)
    {
        currentSpeed = givenSpeed;
        ChangeColor(currentLayer);
    }

    void ChangeColor(MusicLayer givenLayer)
    {
        currentLayer = givenLayer;
        switch (currentSpeed)
        {
            case PlaybackSpeed.Slow:
                switch (currentLayer)
                {
                    case MusicLayer.Dholak:
                        rend.material = slowRed;
                        break;
                    case MusicLayer.Squeaker:
                        rend.material = slowOrange;
                        break;
                    case MusicLayer.Charleston:
                        rend.material = slowYellow;
                        break;
                    case MusicLayer.Sniper:
                        rend.material = slowGreen;
                        break;
                    case MusicLayer.OGProd:
                        rend.material = slowBlue;
                        break;
                    case MusicLayer.Funk:
                        rend.material = slowPurple;
                        break;
                }
                break;
            case PlaybackSpeed.Medium:
                switch (currentLayer)
                {
                    case MusicLayer.Dholak:
                        rend.material = medRed;
                        break;
                    case MusicLayer.Squeaker:
                        rend.material = medOrange;
                        break;
                    case MusicLayer.Charleston:
                        rend.material = medYellow;
                        break;
                    case MusicLayer.Sniper:
                        rend.material = medGreen;
                        break;
                    case MusicLayer.OGProd:
                        rend.material = medBlue;
                        break;
                    case MusicLayer.Funk:
                        rend.material = medPurple;
                        break;
                }
                break;
            case PlaybackSpeed.Fast:
                switch (currentLayer)
                {
                    case MusicLayer.Dholak:
                        rend.material = fastRed;
                        break;
                    case MusicLayer.Squeaker:
                        rend.material = fastOrange;
                        break;
                    case MusicLayer.Charleston:
                        rend.material = fastYellow;
                        break;
                    case MusicLayer.Sniper:
                        rend.material = fastGreen;
                        break;
                    case MusicLayer.OGProd:
                        rend.material = fastBlue;
                        break;
                    case MusicLayer.Funk:
                        rend.material = fastPurple;
                        break;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
