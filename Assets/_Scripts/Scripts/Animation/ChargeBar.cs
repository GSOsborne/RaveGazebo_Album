using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ChargeBar : MonoBehaviour
{
    Transform trans;
    MeshRenderer mRend;
    public float minSize;
    public float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        mRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, minSize + DavisDnB_AudioManager.Instance.chargeLevel/100*(maxSize-minSize));

        if (DavisDnB_AudioManager.Instance.chargeLevel == 0)
        {
            mRend.enabled = false;
        }
        else
        {
            mRend.enabled = true;
        }
    }
}
