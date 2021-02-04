using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class EmissionWithCharge : MonoBehaviour
{
    public float minEmission, maxEmission;
    ParticleSystem pSys;

    // Start is called before the first frame update
    void Start()
    {
        pSys = GetComponent<ParticleSystem>();
        var main = pSys.main;
        main.loop = false;
    }

    public void CorrectColor()
    {
        var main = pSys.main;
        main.loop = true;
        pSys.Play();
    }

    public void StopOnWrongColor()
    {
        var main = pSys.main;
        main.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = pSys.emission;
        emission.rateOverTimeMultiplier = DavisDnB_AudioManager.Instance.chargeLevel / 100 * (maxEmission - minEmission) + minEmission;
        //Debug.Log(emission.rateOverTimeMultiplier);
    }
}