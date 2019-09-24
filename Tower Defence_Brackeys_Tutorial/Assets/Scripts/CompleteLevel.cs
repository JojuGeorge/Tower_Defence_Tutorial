using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string _nextLevel;
    [SerializeField] private int _levelToUnlock = 2;

    public void Continue()
    {
        Debug.Log("Next level");
        PlayerPrefs.SetInt("levelReached", _levelToUnlock);      // for unlocking the 2nd level
        _sceneFader.FadeTo(_nextLevel);
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("Main_Menu");
        _sceneFader.FadeTo("Main_Menu");
    }
}
