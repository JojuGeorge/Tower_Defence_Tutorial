using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private SceneFader _sceneFader;

    private void Start()
    {
        PlayerPrefs.SetInt("levelReached", 1);       // for testing
    }

    public void Play()
    {
        //SceneManager.LoadScene(_levelToLoad);
        _sceneFader.FadeTo(_levelToLoad);
    }

    public void Quit()
    {
        print("Exiting");
        Application.Quit();
    }
}

