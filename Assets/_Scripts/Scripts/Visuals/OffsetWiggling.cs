using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetWiggling : MonoBehaviour
{
    public float wiggleSpeed;
    Renderer rend;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rend.material.mainTextureOffset);
        //rend.material.mainTextureOffset += new Vector2(wiggleSpeed, 0);
        offset += new Vector2(wiggleSpeed, 0);
        //Debug.Log(offset);
        rend.material.SetVector("OffsetVector2", offset);
        //Debug.Log(rend.material.SetVector("OffsetVector2", new Vector)
    }
}
