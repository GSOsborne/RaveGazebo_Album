using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ChargeBarColorChange : MonoBehaviour
{

    Renderer rend;
    public Color redColor, orangeColor, yellowColor, greenColor, blueColor, purpleColor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DavisDnB_AudioManager.WallTriggerEvent += ChangeSharedColor;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeSharedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSharedColor(MusicLayer givenLayer)
    {
        switch (givenLayer)
        {
            case MusicLayer.Dholak:
                rend.sharedMaterial.color = redColor;
                rend.sharedMaterial.SetColor("_EmissionColor", redColor);
                break;
            case MusicLayer.Squeaker:
                rend.sharedMaterial.color = orangeColor;
                rend.sharedMaterial.SetColor("_EmissionColor", orangeColor);
                break;
            case MusicLayer.Charleston:
                rend.sharedMaterial.color = yellowColor;
                rend.sharedMaterial.SetColor("_EmissionColor", yellowColor);
                break;
            case MusicLayer.Sniper:
                rend.sharedMaterial.color = greenColor;
                rend.sharedMaterial.SetColor("_EmissionColor", greenColor);
                break;
            case MusicLayer.OGProd:
                rend.sharedMaterial.color = blueColor;
                rend.sharedMaterial.SetColor("_EmissionColor", blueColor);
                break;
            case MusicLayer.Funk:
                rend.sharedMaterial.color = purpleColor;
                rend.sharedMaterial.SetColor("_EmissionColor", purpleColor);
                break;
        }
    }
}
