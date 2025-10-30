using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("UI References")]
    public GameObject winCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Active le Canvas de victoire
            winCanvas.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    private void UnlockNewLevel()
    {

        // Verifie si le niveau actuel est plus grand ou egal au niveau atteint et débloque le prochain lvl
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedLevel"))
        {
            PlayerPrefs.SetInt("ReachedLevel", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
