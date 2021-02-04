using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static DavisDnB_AudioManager;

public class RandomizeTiling : MonoBehaviour
{

    Renderer rend;
    public float minXTiling, maxXTiling, loopXTime;
    public float minYTiling, maxYTiling, loopYTime;
    public float minXOffset, maxXOffset, loopXOffsetTime;
    public float minYOffset, maxYOffset, loopYOffsetTime;

    float xTile, yTile, xOffset, yOffset;

    public float minTileMultiplier, tileMultiplierDecayFrames;
    float tileMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        tileMultiplier = 1f;
        DavisDnB_AudioManager.StartSongEvent += StartCycling;
        DavisDnB_AudioManager.StopAllMusic += StopThoseCoroutines;
        
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.StartSongEvent -= StartCycling;
        DavisDnB_AudioManager.StopAllMusic -= StopThoseCoroutines;
    }

    void StartCycling(SongName songName)
    {
        StartCoroutine(CycleXTile());
        StartCoroutine(CycleYTile());
        StartCoroutine(CycleXOffset());
        StartCoroutine(CycleYOffset());
    }

    IEnumerator CycleXTile()
    {
        bool forever = true;
        while (forever)
        {
            for (float i = 0; i <=loopXTime; i++)
            {
                xTile = Mathf.SmoothStep(minXTiling, maxXTiling, i / loopXTime);
                //Debug.Log("XTile = " + XTile);
                yield return null;
            }
            for (float i = loopXTime; i >= 0f; i--)
            {
                xTile = Mathf.SmoothStep(minXTiling, maxXTiling, i / loopXTime);
                //Debug.Log("XTile = " + XTile);
                yield return null;
            }

        }
    }

    IEnumerator CycleYTile()
    {
        bool forever = true;
        while (forever)
        {
            for (float i = 0; i <= loopYTime; i++)
            {
                //YTile = minYTiling + i / loopYTime * (maxYTiling - minYTiling);
                yTile = Mathf.SmoothStep(minYTiling, maxYTiling, i / loopYTime);
                //Debug.Log("YTile = " + YTile);
                yield return null;
            }
            for (float i = loopYTime; i >= 0f; i--)
            {
                yTile = Mathf.SmoothStep(minYTiling, maxYTiling, i / loopYTime);
                //Debug.Log("YTile = " + YTile);
                yield return null;
            }

        }
    }

    IEnumerator CycleXOffset()
    {
        bool forever = true;
        while (forever)
        {
            for (float i = 0; i <= loopXOffsetTime; i++)
            {
                xOffset = Mathf.SmoothStep(minXOffset, maxXOffset, i / loopXOffsetTime);
                //Debug.Log("XTile = " + XTile);
                yield return null;
            }
            for (float i = loopXOffsetTime; i >= 0f; i--)
            {
                xOffset = Mathf.SmoothStep(minXOffset, maxXOffset, i / loopXOffsetTime);
                //Debug.Log("XTile = " + XTile);
                yield return null;
            }

        }
    }

    IEnumerator CycleYOffset()
    {
        bool forever = true;
        while (forever)
        {
            for (float i = 0; i <= loopYOffsetTime; i++)
            {
                //YOffset = minYOffset + i / loopYOffsetTime * (maxYOffset - minYOffset);
                yOffset = Mathf.SmoothStep(minYOffset, maxYOffset, i / loopYOffsetTime);
                //Debug.Log("YTile = " + YTile);
                yield return null;
            }
            for (float i = loopYOffsetTime; i >= 0f; i--)
            {
                yOffset = Mathf.SmoothStep(minYOffset, maxYOffset, i / loopYOffsetTime);
                //Debug.Log("YTile = " + YTile);
                yield return null;
            }

        }
    }

    void StopThoseCoroutines()
    {
        StopAllCoroutines();
    }

    public void BoostTileMultiplier()
    {
        //Debug.Log("Boosting!");
        StartCoroutine(BoostTileRoutine());
    }

    IEnumerator BoostTileRoutine()
    {
        tileMultiplier = Mathf.Lerp(1f, minTileMultiplier, .5f);
        yield return null;
        tileMultiplier = Mathf.Lerp(1f, minTileMultiplier, .7f);
        yield return null;
        tileMultiplier = Mathf.Lerp(1f, minTileMultiplier, .9f);
        yield return null;
        tileMultiplier = minTileMultiplier;
        yield return null;
        for (float i = tileMultiplierDecayFrames; i >= 0; i--)
        {
            tileMultiplier = Mathf.SmoothStep(1f, minTileMultiplier, i / tileMultiplierDecayFrames);
            yield return null;
        }
        //Debug.Log("Finished Boosting!");
    }

    // Update is called once per frame
    void Update()
    {
        if (DavisDnB_AudioManager.Instance.songPlaying)
        {
            rend.material.mainTextureScale = new Vector2(xTile*tileMultiplier, yTile*tileMultiplier);
            rend.material.mainTextureOffset = new Vector2(xOffset, yOffset);
        }
    }
}
