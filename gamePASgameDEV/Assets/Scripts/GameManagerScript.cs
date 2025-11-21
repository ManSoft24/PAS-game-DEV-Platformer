using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f; // Ensure the game is running at normal speed
        player.SetActive(true); // Ensure the player is active
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void restart()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("GameManagerScript: Restarting the game by loading GameScenes scene.");
        SceneManager.LoadScene("GameScenes");
    }
    public void mainMenu()
    {
        Debug.Log("GameManagerScript: Loading MainMenu scene.");
        SceneManager.LoadScene("MainMenu");
    }
}
