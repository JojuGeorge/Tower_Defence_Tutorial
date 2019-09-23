using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverUI;
   
    public static bool gameIsOver;

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
}
