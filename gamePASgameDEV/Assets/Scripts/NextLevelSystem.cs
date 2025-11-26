using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSystem : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void nextLevel()
    {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
            Debug.Log("Level Complete!");
    }
}
