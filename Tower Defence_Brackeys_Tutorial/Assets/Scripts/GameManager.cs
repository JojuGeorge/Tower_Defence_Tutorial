using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

  
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _completeGameUI;
   
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
        _completeGameUI.SetActive(true);
    }
  
}
