using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DavisDnB_AudioManager;
using TMPro;

public class SceneChangeSphere : MonoBehaviour
{
    public string sceneName;
    bool readyToChangeScene;
    public float fadeToTransSpeed, fadeToOpaqueSpeed;
    Renderer rend;
    public Color sphereColor;
    public TextMeshPro tmpText;
    Color32 tmpColor;
    Color32 tmpOutlineColor;
    Color32 tmpUnderlayColor;

    // Start is called before the first frame update
    void Start()
    {

        DavisDnB_AudioManager.StopAllMusic += MakeAvailable;
        DavisDnB_AudioManager.StartSongEvent += MakeUnavailable;
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", sphereColor);
        rend.material.SetColor("_EmissionColor", sphereColor);
        rend.material.SetColor("_OutlineColor", new Color(0f, 0f, 0f, 1f));
        tmpColor = tmpText.color;
        tmpOutlineColor = tmpText.outlineColor;
        MakeAvailable();
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.StopAllMusic -= MakeAvailable;
        DavisDnB_AudioManager.StartSongEvent -= MakeUnavailable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeAvailable()
    {
        readyToChangeScene = true;
        StopAllCoroutines();
        StartCoroutine(FadeToOpaque());
    }

    void MakeUnavailable(SongName songName)
    {
        readyToChangeScene = false;
        StopAllCoroutines();
        StartCoroutine(FadeToTransparent());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller" && readyToChangeScene)
        {
            SceneChangeManager.Instance.LoadNewScene(sceneName);
        }
    }

    IEnumerator FadeToTransparent()
    {
        //Debug.Log("a value is: " + rend.material.color.a);
        while (rend.material.GetColor("_Color").a > 0)
        {
            float transparencyFloat = rend.material.color.a - fadeToTransSpeed;
            if (transparencyFloat < 0)
            {
                transparencyFloat = 0;
            }
            Debug.Log("a value is: " + transparencyFloat);
            rend.material.SetColor("_Color", new Color(sphereColor.r, sphereColor.g, sphereColor.b, transparencyFloat));
            rend.material.SetColor("_OutlineColor", new Color(0f, 0f, 0f, transparencyFloat));
            tmpText.faceColor = new Color32(tmpColor.r, tmpColor.g, tmpColor.b, (byte)(Mathf.FloorToInt(transparencyFloat * 255)));
            tmpText.outlineColor = new Color32(tmpOutlineColor.r, tmpOutlineColor.g, tmpOutlineColor.b, (byte)(Mathf.FloorToInt(transparencyFloat * 255)));
            yield return null;
        }
        rend.material.SetColor("_Color", new Color(sphereColor.r, sphereColor.g, sphereColor.b, 0f));
        rend.material.SetColor("_OutlineColor", new Color(0f, 0f, 0f, 0f));
        tmpText.faceColor = new Color32(tmpColor.r, tmpColor.g, tmpColor.b, 0);
        tmpText.outlineColor = new Color32(tmpOutlineColor.r, tmpOutlineColor.g, tmpOutlineColor.b, 0);

    }

    IEnumerator FadeToOpaque()
    {
        //Debug.Log("a value is: " + rend.material.color.a);
        while (rend.material.GetColor("_Color").a < 1)
        {

            float transparencyFloat = rend.material.color.a + fadeToOpaqueSpeed;
            if (transparencyFloat > 1)
            {
                transparencyFloat = 1;
            }
            //Debug.Log("a value is: " + rend.material.color.a);
            rend.material.SetColor("_Color", new Color(sphereColor.r, sphereColor.g, sphereColor.b, transparencyFloat));
            rend.material.SetColor("_OutlineColor", new Color(0f, 0f, 0f, transparencyFloat));
            tmpText.faceColor = new Color32(tmpColor.r, tmpColor.g, tmpColor.b, (byte)(Mathf.FloorToInt(transparencyFloat * 255)));
            tmpText.outlineColor = new Color32(tmpOutlineColor.r, tmpOutlineColor.g, tmpOutlineColor.b, (byte)(Mathf.FloorToInt(transparencyFloat * 255)));
            yield return null;
        }
        rend.material.SetColor("_Color", new Color(sphereColor.r, sphereColor.g, sphereColor.b, 1f));
        rend.material.SetColor("_OutlineColor", new Color(0f, 0f, 0f, 1f));
        tmpText.faceColor = new Color32(tmpColor.r, tmpColor.g, tmpColor.b, 255);
        tmpText.outlineColor = new Color32(tmpOutlineColor.r, tmpOutlineColor.g, tmpOutlineColor.b, 255);
    }
}
