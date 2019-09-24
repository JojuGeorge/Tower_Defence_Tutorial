using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    [SerializeField] private Text _rounds;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        int round = 0;
        _rounds.text = round.ToString();

        yield return new WaitForSeconds(0.5f);      // Wait until the fade animatin is completed

        while (round < PlayerStats.rounds) {
            round++;
            _rounds.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }

    }
}
