/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static DavisDnB_AudioManager;

public class SaturationWithCharge : MonoBehaviour
{
    public PostProcessVolume ppVolume;
    private ColorGrading cGrading;
    float gazeboCharge;

    public float startMinSat, startMaxSat, finalMinSat, finalMaxSat, boostPerWall;
    private float currentMinSat, currentMaxSat;
    // Start is called before the first frame update
    void Start()
    {
        ppVolume.profile.TryGetSettings(out cGrading);
        currentMinSat = startMinSat;
        currentMaxSat = startMaxSat;
        cGrading.saturation.value = startMinSat;

        DavisDnB_AudioManager.WallTriggerEvent += AdjustMinMax;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= AdjustMinMax;
    }

    void AdjustMinMax(MusicLayer mLayer)
    {
        currentMinSat = Mathf.Min(currentMinSat + boostPerWall, finalMinSat);
        if (DavisDnB_AudioManager.Instance.chargeLevel > 80)
        {
            currentMaxSat = Mathf.Min(currentMaxSat + boostPerWall, finalMaxSat);
        }

    }

    // Update is called once per frame
    void Update()
    {
        gazeboCharge = (DavisDnB_AudioManager.Instance.chargeLevel/100 * (currentMaxSat-currentMinSat) + currentMinSat);
        //Debug.Log(gazeboCharge);
        cGrading.saturation.value = gazeboCharge;
    }
}

*/