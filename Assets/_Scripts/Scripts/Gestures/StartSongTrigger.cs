using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class StartSongTrigger : MonoBehaviour
{
    public float fadeSpeed = 1;
    public GameObject textToTurnOff;
    CapsuleCollider triggerCollider;
    MeshRenderer mesh;
    public AK.Wwise.Event startSongEvent;
    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<CapsuleCollider>();
        mesh = GetComponent<MeshRenderer>();
        StartSongEvent += StartFadeOut;
        StopAllMusic += StartFadeIn;
    }

    private void OnDestroy()
    {
        StartSongEvent -= StartFadeOut;
        StopAllMusic -= StartFadeIn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Something has tried to enter this song collider *SLURP*");
        if (other.tag == "Controller")
        {
            Instance.StartASong(SongName.DavisDnB);

            //Also immediately want to disable trigger status just in case
            triggerCollider.enabled = false;
        }
    }

    void StartFadeOut(SongName songName)
    {
        StartCoroutine(FadeOut());
    }

    void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        triggerCollider.enabled = false;
        mesh.enabled = false;
        textToTurnOff.SetActive(false);
        yield return null;
        /*
        Debug.Log("Called Fade Out");
        // Assigns the color as the material in the mesh rendere
        Material mat = this.GetComponent<MeshRenderer>().material;
        Debug.Log(mat.color);
        Debug.Log("I have started my coroutine!");

        // Loops until the object is transparent
        while (mat.color.a > 0)
        {

            Color newColor = mat.color;
            newColor.a -= Time.deltaTime * fadeSpeed;
            // c.a = the opacity of the color 
            //Debug.Log(newColor.a);
            mat.color = newColor;

            yield return newColor;
        }
        // when the object is transparent it will be destroyed
        Debug.Log("End of fade");

        //Object.Destroy(this.gameObject);
        */
    }

    public IEnumerator FadeIn()
    {
        triggerCollider.enabled = true;
        mesh.enabled = true;
        textToTurnOff.SetActive(true);

        yield return null;
        /*Debug.Log("Called Fade In");
        Material mat = this.GetComponentInChildren<MeshRenderer>().material;
        Color invisibleColor = mat.color;
        invisibleColor.a = 0f;
        mat.color = invisibleColor;

        while (mat.color.a < 1)
        {
            Color newColor = mat.color;
            newColor.a += Time.deltaTime * fadeSpeed;
            // c.a = the opacity of the color 
            //Debug.Log(newColor.a);
            mat.color = newColor;

            yield return newColor;
        }

        //now that done fading, use as collider
        triggerCollider.enabled = true;
        */
    }
}
