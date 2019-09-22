using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 4;

    void Start()
    {
        lives = startLives;
        money = startMoney;
    }

    private void Update()
    {
        if(lives <=0)
        {
            lives = 0;
        }
    }

}
