using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowFadeScript : MonoBehaviour
{
    Renderer rend;
    public float frameLength;
    bool forever;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(ColorShiftRedToMagenta());
    }

    // Update is called once per frame
    void Update()
    {
        //rend.sharedMaterial.SetColor("_Color", new Color (Mathf.PingPong(Time.time * fadeSpeed, 1), 1, 1));
        
    }
    IEnumerator ColorShiftRedToMagenta()
    {
        forever = true;
        Debug.Log("Starting the forever color shift!");
        while (forever)
        {
            //Debug.Log("Starting the loop");
            for (float i = 0; i <= 40; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(Color.red, Color.magenta, i / 40);
                //Debug.Log(Color.Lerp(Color.red, Color.magenta, i / 100));
                yield return new WaitForSeconds(frameLength);
            }
            //Debug.Log("Should have turned magenta!");
            for (float i = 0; i <= 40; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(Color.magenta, Color.blue, i / 40);
                yield return new WaitForSeconds(frameLength);
            }
            //Debug.Log("Should have turned blue!");
            for (float i = 0; i <= 40; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(Color.blue, Color.green, i / 40);
                yield return new WaitForSeconds(frameLength);
            }
            //Debug.Log("Should have turned green!");
            for (float i = 0; i <= 40; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(Color.green, Color.yellow, i / 40);
                yield return new WaitForSeconds(frameLength);
            }
            //Debug.Log("Should have turned yellow!");
            for (float i = 0; i <= 40; i++)
            {
                rend.sharedMaterial.color = Color.Lerp(Color.yellow, Color.red, i / 40);
                yield return new WaitForSeconds(frameLength);
            }
            //Debug.Log("Should have turned red!");
        }
    }
}
