using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientCycleForever : MonoBehaviour
{

    public Gradient shiftingColorGradient;
    Renderer rend;
    public float minFadeFrames, maxFadeFrames;
    bool forever;
    // Start is called before the first frame update
    void Start()
    {
        forever = true;
        rend = GetComponent<Renderer>();
        StartCoroutine(FadeToGradientValueOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeToGradientValueOverTime()
    {
        Color startingColor;
        while (forever)
        {
            //Debug.Log("Shifting Colors!");
            startingColor = rend.sharedMaterial.color;
            float fadeFrames = Random.Range(minFadeFrames, maxFadeFrames);
            //Debug.Log("Fade will last " + fadeFrames + " frames.");
            float chosenGradientColor = Random.Range(0f, 1f);
            for (int i = 0; i <= fadeFrames; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(startingColor, shiftingColorGradient.Evaluate(chosenGradientColor), i / fadeFrames);
                yield return null;
            }

        }
    }
}
