using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class GazeTrigger : MonoBehaviour
{
    public PanelLifter pLift;

    float elapsed;
    public float requiredGazeTime;
    public float timeBeforeReset;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (DavisDnB_AudioManager.Instance.songPlaying)
        {


            if (other.gameObject.CompareTag("Gaze"))
            {
                StopAllCoroutines();
                elapsed += Time.fixedDeltaTime;
                if (elapsed > requiredGazeTime && !pLift.panelRaised)
                {
                    pLift.RaisePanels();
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gaze"))
        {
            elapsed = 0f;
            StartCoroutine(WaitBeforeReset());
        }
    }

    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(timeBeforeReset);
        pLift.LowerPanels();
    }
}
