﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class WiggleSpeedWithCharge : MonoBehaviour
{
    OffsetWiggling offsetWiggling;
    public float minSpeed, maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offsetWiggling = GetComponent<OffsetWiggling>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetWiggling.wiggleSpeed = (DavisDnB_AudioManager.Instance.chargeLevel / 100) * (maxSpeed - minSpeed) + minSpeed;
    }
}
