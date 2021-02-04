using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using static FadeController;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager Instance;

    public UnityEvent OnLoadBegin = new UnityEvent();
    public UnityEvent OnLoadEnd = new UnityEvent();
    //public ScreenFader screenFader = null;

    bool isLoading;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Uh, there's two of me. Bye!");
            Destroy(this);
        }
        SceneManager.sceneLoaded += SetActiveScene;
        isLoading = false;

    }

    public void LoadNewScene(string sceneName)
    {
        if (!isLoading)
        {
            StartCoroutine(LoadScene(sceneName));
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        isLoading = true;

        OnLoadBegin?.Invoke();
        //yield return screenFader
        FadeController.Instance.StartFadeOut();
        yield return new WaitForSeconds(FadeController.Instance.fadeOutTime+.3f);
        //yield return StartCoroutine(UnloadCurrent());

        //for testing
        //yield return new WaitForSeconds(3.0f);

        yield return StartCoroutine(LoadNew(sceneName));
        FadeController.Instance.StartFadeIn();
        yield return new WaitForSeconds(FadeController.Instance.fadeBackInTime);
        OnLoadEnd?.Invoke();

        isLoading = false;
    }

    IEnumerator UnloadCurrent()
    {
        Debug.Log("Starting to Unload " + SceneManager.GetActiveScene().name);
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadOperation.isDone)
        {
            yield return null;
            
        }
        Debug.Log("Done Unloading!");
    }

    IEnumerator LoadNew(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
        Debug.Log("Done Loading " + sceneName);

    }

    public void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Setting the active scene to " + scene.name);
        SceneManager.SetActiveScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Active Scene is: " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
