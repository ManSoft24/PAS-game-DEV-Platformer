using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void playButton ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScenes");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
    