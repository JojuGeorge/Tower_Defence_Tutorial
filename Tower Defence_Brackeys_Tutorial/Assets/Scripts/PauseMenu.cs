using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
