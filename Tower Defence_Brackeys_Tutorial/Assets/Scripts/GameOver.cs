using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _rounds;
    [SerializeField] private SceneFader _sceneFader;

    private void OnEnable()
    {
        _rounds.text = PlayerStats.rounds.ToString();
    }

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
