using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Button[] _levelButtons;

    private void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // For locking levels
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                _levelButtons[i].interactable = false;
            }
        }
    }

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
