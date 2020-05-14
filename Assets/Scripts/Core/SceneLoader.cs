using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject LoadingScene;
    public Slider slider;

    public void LoadScene(int SceneIndex)
    {

        StartCoroutine(LoadAsync(SceneIndex));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScene.SetActive(true);

        while(op.isDone == false)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
