using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject loadingScreenPanel;
    public GameObject mainMenuPanel;

  public void playButton ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScenes");
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void loadingScreen()
  {
    loadingScreenPanel.SetActive(true);
    StartCoroutine(LoadSceneAsync("GameScenes"));
  }

  IEnumerator LoadSceneAsync(String sceneName)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    operation.allowSceneActivation = false;

    while (!operation.isDone)
    {
      
      float progress = Mathf.Clamp01(operation.progress / 0.9f);
      Debug.Log("Loading progress: " + (progress * 100) + "%");
      
      if (operation.progress >= 0.9f)
      {
        yield return new WaitForSeconds(3f);
        operation.allowSceneActivation = true;
      }
      yield return null;
    }
    loadingScreenPanel.SetActive(false);
  }
}
    