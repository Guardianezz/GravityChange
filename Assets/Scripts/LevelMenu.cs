using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] levelButtons;

    private void Awake()
    {
        int UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        // Disable buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        // Enable buttons
        for (int i = 0; i < UnlockedLevel; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        string sceneName = "Lvl" + levelId;
        SceneManager.LoadScene(sceneName);
    }
}
