using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string _nextLevel;
    [SerializeField] private int _levelToUnlock = 2;
    [SerializeField] private GameObject _gameOverUI;
   
    public static bool gameIsOver;

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
    }

    private void Start()
    {
        gameIsOver = false;
    }


    void Update()
    {

        if (gameIsOver) { return; }

        if(PlayerStats.lives <= 0)
        {
            gameIsOver = true;
            PlayerStats.lives = 0;
            EndGame();
        }

        //todo Debugging
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }
    }



    private void EndGame()
    {
        _gameOverUI.SetActive(true);
    }

    public void LevelWon()
    {
        Debug.Log("Next level");
        PlayerPrefs.SetInt("levelReached", _levelToUnlock);      // for unlocking the 2nd level
        _sceneFader.FadeTo(_nextLevel);
    }
}
