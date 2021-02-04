using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class OutlineColorChange : MonoBehaviour
{
    Renderer rend;
    public Color ogColor, whenPurple, whenBlue, whenGreen, whenYellow, whenOrange, whenRed;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial.SetColor("_Color", ogColor);
        DavisDnB_AudioManager.WallTriggerEvent += ColorSlide;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ColorSlide;
    }

    public void ColorSlide(MusicLayer givenLayer)
    {
        switch (givenLayer)
        {
            case MusicLayer.Funk:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenPurple));
                break;
            case MusicLayer.OGProd:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenBlue));
                break;
            case MusicLayer.Sniper:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenGreen));
                break;
            case MusicLayer.Charleston:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenYellow));
                break;
            case MusicLayer.Squeaker:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenOrange));
                break;
            case MusicLayer.Dholak:
                StopAllCoroutines();
                StartCoroutine(SlideToColor(whenRed));
                break;

        }
    }

    IEnumerator SlideToColor(Color givenColor)
    {
        Color startColor = rend.sharedMaterial.GetColor("_Color");
        for (float i = 0; i <= 10; i++)
        {
            rend.sharedMaterial.SetColor("_Color", Color.Lerp(startColor, givenColor, i / 10));
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
