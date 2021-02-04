using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColorDuringSpeed : MonoBehaviour
{
    public VaryMaterialDuringSpeed mimicColorScript;
    Renderer rend;
    public Color defaultColor;

    bool returnedToDefault;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        returnedToDefault = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mimicColorScript.currentlyShifting)
        {
            StopAllCoroutines();
            rend.sharedMaterial.color = (mimicColorScript.currentColor*2 + defaultColor)/3;
            returnedToDefault = false;
        }
        else if (!returnedToDefault)
        {
            returnedToDefault = true;
            StartCoroutine(ReturnToDefaultColor());

        }
    }

    IEnumerator ReturnToDefaultColor()
    {
        Color startingColor = rend.sharedMaterial.color;
        for (int i = 0; i<=30; i++)
        {
            rend.sharedMaterial.color = Color.Lerp(startingColor, defaultColor, i / 30f);
            yield return null;
        }
    }
}
