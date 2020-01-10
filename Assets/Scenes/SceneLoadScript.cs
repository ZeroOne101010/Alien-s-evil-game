using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadScript : MonoBehaviour
{
    public string sceneName;
    public Image progressCircle;
    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            progressCircle.fillAmount =     progress;
            yield return null;
        }
    }

}
