using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //FindObjectOfType<gamestatus>().Resetgame();
    }

    public void LoadNextScenestart()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        FindObjectOfType<gamesession>().Resetgame();
    }
    public void quitgame()
    {
        Application.Quit();
    }


}
