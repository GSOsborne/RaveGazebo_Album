using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ColorSystemManager : MonoBehaviour
{
    public Renderer primaryRenderer, secondaryRenderer, tertiaryRenderer, backgroundRenderer;
    Material primaryColorMat, secondaryColorMat, tertiaryColorMat, backgroundColorMat;
    public Color redColor, orangeColor, yellowColor, greenColor, blueColor, purpleColor;

    // Start is called before the first frame update
    void Start()
    {
        primaryColorMat = primaryRenderer.material;
        secondaryColorMat = secondaryRenderer.material;
        tertiaryColorMat = tertiaryRenderer.material;
        backgroundColorMat = backgroundRenderer.material;



        primaryColorMat.SetColor("_MainColor", Color.white);
        secondaryColorMat.SetColor("_MainColor", Color.white);
        tertiaryColorMat.SetColor("_MainColor", Color.white);
        backgroundColorMat.SetColor("_MainColor", Color.white);
        DavisDnB_AudioManager.WallTriggerEvent += UpdateColor;

    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= UpdateColor;
    }

    void UpdateColor(MusicLayer mLayer)
    {
        //Debug.Log("UpdatingColor!");
        tertiaryColorMat.SetColor("_MainColor", secondaryColorMat.GetColor("_MainColor"));
        secondaryColorMat.SetColor("_MainColor", primaryColorMat.GetColor("_MainColor"));
        primaryColorMat.SetColor("_MainColor", backgroundColorMat.GetColor("_MainColor"));
        
        
        switch (mLayer)
        {
            case MusicLayer.Charleston:
                //primaryColorMat.SetColor("_MainColor", yellowColor);
                backgroundColorMat.SetColor("_MainColor", yellowColor);
                break;
            case MusicLayer.Dholak:
                //primaryColorMat.SetColor("_MainColor", redColor);
                backgroundColorMat.SetColor("_MainColor", redColor);
                break;
            case MusicLayer.Funk:
                //primaryColorMat.SetColor("_MainColor", purpleColor);
                backgroundColorMat.SetColor("_MainColor", purpleColor);
                break;
            case MusicLayer.OGProd:
                //primaryColorMat.SetColor("_MainColor", blueColor);
                backgroundColorMat.SetColor("_MainColor", blueColor);
                break;
            case MusicLayer.Sniper:
                //primaryColorMat.SetColor("_MainColor", greenColor);
                backgroundColorMat.SetColor("_MainColor", greenColor);
                break;
            case MusicLayer.Squeaker:
                //primaryColorMat.SetColor("_MainColor", orangeColor);
                backgroundColorMat.SetColor("_MainColor", orangeColor);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
