using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    
    [Header("UI Buttons")]
    public Button levelButton;

    [SerializeField] public string LevelName;

     private void Start()
    {
        // Par défaut, seul le niveau 1 est débloqué
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Si le joueur n’a PAS fini le niveau 1, cache le bouton "Level"
        if (unlockedLevel <= 1)
        {
            levelButton.gameObject.SetActive(false);
        }
        else
        {
            levelButton.gameObject.SetActive(true);
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(LevelName);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void QuitButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Application.Quit();
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void PreviousLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void ToggleButton()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void PauseButton()
    {

        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
