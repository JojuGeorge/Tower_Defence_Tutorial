using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    public void Select(string levelToLoad)
    {
        if (levelToLoad != "")
        {
            _sceneFader.FadeTo(levelToLoad);
        }
        else
        {
            Debug.LogWarning("No level is set to open on click");
        }
    }
}
