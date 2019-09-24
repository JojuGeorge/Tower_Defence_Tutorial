using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private SceneFader _sceneFader;
    private bool _isPaused;

    private void Start()
    {
        _isPaused = false;
    }



    void Update()
    {
        // pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
        {
            Time.timeScale = 0f;
            _pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pauseMenuUI.SetActive(false);
        }
    }

    public void Continue() {
        _isPaused = false;
    }

    public void Retry()
    {
        _isPaused = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        _isPaused = false;
        //SceneManager.LoadScene("Main_Menu");
        _sceneFader.FadeTo("Main_Menu");
    }
}
