using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class Song2ControllerColorChangeOnGesture : MonoBehaviour
{
    Renderer rend;
    public Color redColor, orangeColor, yellowColor, greenColor, blueColor, purpleColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DavisDnB_AudioManager.WallTriggerEvent += ChangeControllerMatColor;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeControllerMatColor;
    }

    void ChangeControllerMatColor(MusicLayer givenLayer)
    {
        switch (givenLayer)
        {
            case MusicLayer.Charleston:
                rend.sharedMaterial.SetColor("_EmissionColor", yellowColor);
                break;
            case MusicLayer.Dholak:
                rend.sharedMaterial.SetColor("_EmissionColor", redColor);
                break;
            case MusicLayer.Funk:
                rend.sharedMaterial.SetColor("_EmissionColor", purpleColor);
                break;
            case MusicLayer.OGProd:
                rend.sharedMaterial.SetColor("_EmissionColor", blueColor);
                break;
            case MusicLayer.Sniper:
                rend.sharedMaterial.SetColor("_EmissionColor", greenColor);
                break;
            case MusicLayer.Squeaker:
                rend.sharedMaterial.SetColor("_EmissionColor", orangeColor);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
