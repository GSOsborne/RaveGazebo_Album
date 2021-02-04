using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMaterialEmissionColorDuringSpeed : MonoBehaviour
{
    public VaryMaterialDuringSpeed mimicColorScript;
    Renderer rend;
    public Color defaultColor;

    bool returnedToDefault;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial.SetColor("_EmissionColor", defaultColor);
        returnedToDefault = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mimicColorScript.currentlyShifting)
        {
            StopAllCoroutines();
            rend.sharedMaterial.SetColor("_EmissionColor", mimicColorScript.currentColor*.8f);
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
        for (int i = 0; i <= 30; i++)
        {
            rend.sharedMaterial.color = Color.Lerp(startingColor, defaultColor, i / 30f);
            yield return null;
        }
    }
}
