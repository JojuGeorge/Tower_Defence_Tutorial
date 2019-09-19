using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _countDownTimerText;


    void Update()
    {
        float countDown = Mathf.Round(GameManager.Instance.CountDown);
        _countDownTimerText.text = countDown.ToString();
    }
}
