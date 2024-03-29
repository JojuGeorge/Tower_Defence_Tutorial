﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _countDownTimerText;
    [SerializeField] private Text _lives;
    [SerializeField] private Text _money;

    void Update()
    {
        // Lives
        _lives.text = PlayerStats.lives + " LIVES";

        // Money
        _money.text = string.Format("{0:$0}", PlayerStats.money);

        // Timer
        float countDown = Mathf.Clamp(WaveSpawner.Instance.CountDown, 0, Mathf.Infinity);       // So than countdown is always greater than 0
        _countDownTimerText.text = string.Format("{0:00.00}", countDown);                       // Formatting how time is displayer
    }
}
