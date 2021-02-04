using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class PanelLifter : MonoBehaviour
{
    public Transform cameraHeadObject;
    Transform thisTransform;
    public float frameTime;
    public bool panelRaised;
    float startingTransformY;

    bool panelRecentlySelected;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        panelRaised = false;
        startingTransformY = thisTransform.position.y;
        DavisDnB_AudioManager.PlaybackSpeedChange += ForceLoweringOfPanels;
        panelRecentlySelected = false;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= ForceLoweringOfPanels;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaisePanels()
    {
        if (!panelRecentlySelected)
        {
           // Debug.Log("Someone is trying to raise the panels!");
            if (!panelRaised)
            {
               // Debug.Log("So we're raising the panels now.");
                StopAllCoroutines();
                StartCoroutine(ChangeHeight(cameraHeadObject.position.y / .7f));
                panelRaised = true;
            }
            else
            {
               // Debug.Log("But they were already raised, dummy");
            }
        }
        else
        {
            //Debug.Log("Lady??? you haVE TO WAIT!!!");
        }
    }

    public void LowerPanels()
    {
        //Debug.Log("Someone is trying to lower the panels!");
        if (panelRaised)
        {
           // Debug.Log("So we're lowering the panels now.");
            StopAllCoroutines();
            StartCoroutine(ChangeHeight(startingTransformY));
            panelRaised = false;
        }
        else
        {
           // Debug.Log("But they were already down, lmao");
        }
    }

    void ForceLoweringOfPanels(PlaybackSpeed pSpeed)
    {

        LowerPanels();
        StartCoroutine(WaitBeforeRaisingPanels());
    }

    IEnumerator WaitBeforeRaisingPanels()
    {
        panelRecentlySelected = true;
        yield return new WaitForSeconds(1f);
        panelRecentlySelected = false;
    }

    IEnumerator ChangeHeight(float desiredY)
    {
        float startingY = thisTransform.position.y;
        for (float i = 0; i <=30; i++)
        {
            thisTransform.position = new Vector3(thisTransform.position.x, Mathf.SmoothStep(startingY, desiredY, i / 30));
            //Debug.Log(Mathf.SmoothStep(startingY, desiredY, i / 100));
            yield return new WaitForSeconds(frameTime);
        }
        Debug.Log("Should be done moving the panels now.");
    }

}
