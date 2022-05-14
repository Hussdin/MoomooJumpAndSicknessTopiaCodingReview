using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene scene;
    AsyncOperation loadingoperation;
    [SerializeField]
    Slider progressbar;
    [SerializeField]
    Text percent;

    public GameObject loadingScreen;
    private void Awake()
    {
        scene = this;
    }
    public void Loadscene()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressbar.value = progress;
            percent.text = Mathf.Round(progress * 100) + "%";

            yield return null;
        }
    }
}
