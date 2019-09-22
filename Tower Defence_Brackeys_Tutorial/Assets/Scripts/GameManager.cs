using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool _gameEnded = false;

    void Update()
    {
        if(_gameEnded) { return; }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
            _gameEnded = true;
            PlayerStats.lives = 0;
        }
    }

    private void EndGame()
    {
        print("GameOver");
    }
}
