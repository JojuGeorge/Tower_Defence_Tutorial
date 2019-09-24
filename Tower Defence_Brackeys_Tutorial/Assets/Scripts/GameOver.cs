using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

  

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("Main_Menu");
        _sceneFader.FadeTo("Main_Menu");
    }
}
