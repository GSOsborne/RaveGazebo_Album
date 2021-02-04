using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaryToonOutlineColorDuringSpeed : MonoBehaviour
{
    public VaryMaterialDuringSpeed mimicColorScript;
    Renderer rend;
    public Color defaultOutlineColor;

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
            rend.sharedMaterial.SetColor("_OutlineColor", mimicColorScript.currentColor);
            returnedToDefault = false;
        }
        else if (!returnedToDefault)
        {
            rend.sharedMaterial.SetColor("_OutlineColor", defaultOutlineColor);
            returnedToDefault = true;
        }
    }
}
