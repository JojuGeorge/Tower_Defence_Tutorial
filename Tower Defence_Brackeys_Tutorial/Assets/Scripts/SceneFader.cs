using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private AnimationCurve _fadeInCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0) {
            t -= Time.deltaTime;
            float a = _fadeInCurve.Evaluate(t);
            _img.color = new Color(0f, 0f, 0f, a);
            yield return 0;                          // Skip to the next frame; wait a frame and then continue
        }
    }


    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = _fadeInCurve.Evaluate(t);
            _img.color = new Color(0f, 0f, 0f, a);
            yield return 0;                          // Skip to the next frame; wait a frame and then continue
        }

        SceneManager.LoadScene(scene);
    }

}
