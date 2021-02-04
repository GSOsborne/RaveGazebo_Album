using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class VaryMaterialDuringSpeed : MonoBehaviour
{
    public VaryMaterialDuringSpeed primaryVariance;
    public Gradient shiftingColorGradient;
    public Color returnColor;
    public Color currentColor;
    Renderer rend;
    public PlaybackSpeed shiftingSpeed;

    public int returnToNormalFrames;

    public float minFadeFrames, maxFadeFrames;

    public bool currentlyShifting;
    public bool leaderOfThePack;
    public float publicGradientValue;
    float startingGradientValue;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial.color = returnColor;
        if (leaderOfThePack)
        {
            rend.sharedMaterial.SetColor("_EmissionColor", returnColor);
        }

        DavisDnB_AudioManager.PlaybackSpeedChange += EvaluateFadeNecessity;
        DavisDnB_AudioManager.StopAllMusic += StopShifting;
        startingGradientValue = 0f;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= EvaluateFadeNecessity;
        DavisDnB_AudioManager.StopAllMusic -= StopShifting;
    }

    void EvaluateFadeNecessity(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == shiftingSpeed)
        {
            currentlyShifting = true;
            StopAllCoroutines();
            StartCoroutine(FadeToGradientValueOverTime());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(ReturnToOriginalColor());
        }
    }

    IEnumerator FadeToGradientValueOverTime()
    {
        //Color startingColor;
        while (currentlyShifting)
        {
            //Debug.Log("Shifting Colors!");
            //startingColor = rend.sharedMaterial.color;

            float fadeFrames = Random.Range(minFadeFrames, maxFadeFrames);
            //Debug.Log("Fade will last " + fadeFrames + " frames.");
            float chosenGradientColor = Random.Range(0f, 1f);
            if (leaderOfThePack)
            {
                for (int i = 0; i <= fadeFrames; i++)
                {
                    rend.sharedMaterial.color = Color.Lerp(shiftingColorGradient.Evaluate(startingGradientValue), shiftingColorGradient.Evaluate(chosenGradientColor), i / fadeFrames);
                    currentColor = rend.sharedMaterial.color;
                    rend.sharedMaterial.SetColor("_EmissionColor", currentColor*.8f);
                    publicGradientValue = Mathf.Lerp(startingGradientValue, chosenGradientColor, i / fadeFrames);
                    yield return null;
                }
                startingGradientValue = chosenGradientColor;

            }
            else
            {
                currentColor = shiftingColorGradient.Evaluate(primaryVariance.publicGradientValue);
                rend.sharedMaterial.color = currentColor;
                yield return null;
            }
            
        }
    }

    void StopShifting()
    {
        StopAllCoroutines();
        StartCoroutine(ReturnToOriginalColor());
    }

    IEnumerator ReturnToOriginalColor()
    {
        startingGradientValue = 0f;
        Color startingColor = rend.sharedMaterial.color;
        for(int i = 0; i <= returnToNormalFrames; i++)
        {
            rend.sharedMaterial.color = Color.Lerp(startingColor, returnColor, (float)i/returnToNormalFrames);
            currentColor = rend.sharedMaterial.color;
            //rend.sharedMaterial.SetColor("_EmissionColor", currentColor);

            //Debug.Log(rend.sharedMaterial.color + " with " + (float)i/returnToNormalFrames);
            yield return null;
        }

        currentlyShifting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
